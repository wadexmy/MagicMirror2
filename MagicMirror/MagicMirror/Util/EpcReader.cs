using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.IotLead.Hardware.Device.PcX86.Common.Device.Inter.Reader;
using Com.IotLead.Hardware.Device.PcX86.Common.Device.Controll.Inter;
using Newtonsoft.Json;
using System.IO;
using MagicMirror.Views;
using Com.IotLead.Hardware.Device.PcX86.Common.Device.Impls.RFIDReader;
using Com.IotLead.Hardware.Device.PcX86.Common.Device.DataTransferObjects.Reader;
using Com.IotLead.Hardware.Device.PcX86.Common.Device.Controll.Impls;
using Com.IotLead.Hardware.Device.PcX86.Domain.DataTransferObjects;
using System.ComponentModel;
using MagicMirror.Models;

namespace MagicMirror.Util
{
    class EpcReader
    {
        private IRfidReaderControllerImpl _readerControllerImpler;

        private IRfidReaderController _readerController = null;

        public string readerConfigPath = Global.readerConfigPath;

        private HashSet<string> EpcList;

        public EpcReader()
        {
            EpcList = new HashSet<string>();

            if (!File.Exists(readerConfigPath)) throw new Exception("找不到读写器配置文件！");
            var file = File.ReadAllText(readerConfigPath);
            var localReaderSettings = JsonConvert.DeserializeObject<ReaderWithAntennaDto>(file);

            if (localReaderSettings == null) throw new Exception("请先维护设备！");
            if (localReaderSettings.Reader.Model == "R500")
            {
                _readerControllerImpler = new ImpinjR500ReaderControllerImpl();
                _readerControllerImpler.ReaderTagsHandle += _readerControllerImpler_ReaderTagsHandle;
                try
                {
                    _readerControllerImpler.ConnectAndStart();
                    
                }
                catch (Exception ex)
                {
                    WPFMessageBox.Show("连接设备失败！" + ex.Message);
                }
            }
            //else
            //{
            //    var reader = new Reader()
            //    {
            //        Code = localReaderSettings.Reader.Code,
            //        IpAddress = localReaderSettings.Reader.Ip,
            //        Port = localReaderSettings.Reader.Port,
            //        MemoryBank = 0,
            //        ReaderAntennas = localReaderSettings.ReaderAntennaList.Select(v => new ReaderAntenna
            //        {
            //            Enable = true,
            //            MaxRxSensitivity = v.MaxRxSensitivity,
            //            MaxTransmitPower = v.MaxTransmitPower,
            //            PortNumber = (ushort)v.AntennaIndex,
            //            RxSensitivityInDbm = v.RxSensitivityInDbm,
            //            TxPowerInDbm = v.TxPowerInDbm
            //        }).ToList()
            //    };
            //    _readerController = new MotorolaRfidReaderControllerImpl(reader);
            //    _readerController.ReaderTagsHandle += readerController_ReaderTagsHandle;
            //    try
            //    {
            //        _readerController.ConnectAndStart();
            //    }
            //    catch (Exception ex)
            //    {
            //        WPFMessageBox.Show("连接设备失败！" + ex.Message);
            //    }
            //}
        }

        private void _readerControllerImpler_ReaderTagsHandle(object sender, RfidReaderEventArgs e)
        {
            string epccode=e.EpcDtos[0].EpcCode;
            //System.Windows.MessageBox.Show(e.EpcDtos[0].EpcCode);
            DataService service=new DataService();

            SkuBiz sku = service.GetProductByEpc(epccode);
            _readerControllerImpler.StopAndDisconnect();
            //WPFMessageBox.Show(e.EpcDtos[0].EpcCode);
            //BackgroundWorker bgw = new BackgroundWorker();
            //bgw.WorkerSupportsCancellation = true;
            //bgw.WorkerReportsProgress = true;
            //bgw.DoWork += new DoWorkEventHandler((s1, e1) =>
            //{
            //    //foreach (var epc in e.EpcDtos)
            //    //{
            //    //    if (EpcList.Count == 0 || !(EpcList.Any(x => x.Epc == epc.EpcCode)))
            //    //    {
            //    //        EPC_READ_STATUS epc_tmp = new EPC_READ_STATUS();
            //    //        epc_tmp.Epc = epc.EpcCode;
            //    //        epc_tmp.isAdd = false;
            //    //        EpcList.Add(epc_tmp);
            //    //    }
            //    //}

            //});
            //bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler((s2, e2) =>
            //{
            //    //AddDataToGridView();
            //});
            //bgw.RunWorkerAsync();
            ////this.InvokeIfRequired(() =>
            ////{
            ////    //数据显示
            ////    //AddDataToGridView();
            ////});
        }

        //private void AddDataToGridView()
        //{
        //    string sEpcUnion = string.Join("','", EpcList.Where(x => x.isAdd == false).ToList().Select(x => x.Epc).ToArray());
        //    sEpcUnion = sEpcUnion.Length > 0 ? "'" + sEpcUnion + "'" : sEpcUnion;
        //    if (sEpcUnion.Length > 0)
        //    {
        //        DataRow[] drSet = dtItem.Select(" epc in (" + sEpcUnion + ")");
        //        if (drSet.Length > 0)
        //        {
        //            decimal dAmt = decimal.Parse(lblTotalAmt.Text.Replace("￥", ""));
        //            foreach (DataRow dr_tmp in drSet)
        //            {
        //                gvItem.AddNewRow();
        //                gvItem.SetFocusedRowCellValue(colepc, dr_tmp["epc"]);
        //                //gvItem.SetFocusedRowCellValue(colsmallPic, dr_tmp["smallPic"]);
        //                gvItem.SetFocusedRowCellValue(colbarcode, dr_tmp["barcode"]);
        //                gvItem.SetFocusedRowCellValue(colitem, dr_tmp["item"]);
        //                gvItem.SetFocusedRowCellValue(colcolorName, dr_tmp["colorName"]);
        //                gvItem.SetFocusedRowCellValue(colsizeName, dr_tmp["sizeName"]);
        //                gvItem.SetFocusedRowCellValue(colprice, dr_tmp["price"]);
        //                gvItem.SetFocusedRowCellValue(colName, dr_tmp["name"]);
        //                gvItem.SetFocusedRowCellValue(colqty, 1);
        //                gvItem.SetFocusedRowCellValue(colamt, dr_tmp["price"]);

        //                dAmt = dAmt + decimal.Parse(dr_tmp["price"].ToString());

        //                EpcList.Where(x => x.isAdd == false && x.Epc == dr_tmp["epc"].ToString()).ForEach(x => x.isAdd = true);
        //            }
        //            gvItem.AddNewRow();
        //            gvItem.DeleteRow(gvItem.FocusedRowHandle);

        //            //计算总数量 总金额
        //            lblTotalQty.Text = gvItem.RowCount.ToString();
        //            lblTotalAmt.Text = "￥" + dAmt.ToString();
        //        }
        //    }
        //}

        private void readerController_ReaderTagsHandle(object sender, RfidReaderEventArgs e)
        {
            //e.EpcDtos.ForEach(epc =>
            //{
            //    if (EpcList.Count == 0 || !(EpcList.Any(x => x.Epc == epc.EpcCode)))
            //    {
            //        EPC_READ_STATUS epc_tmp = new EPC_READ_STATUS();
            //        epc_tmp.Epc = epc.EpcCode;
            //        epc_tmp.isAdd = false;
            //        EpcList.Add(epc_tmp);
            //    }
            //});

            //this.InvokeIfRequired(() =>
            //{
            //    AddDataToGridView();
            //});
        }

    }
}
