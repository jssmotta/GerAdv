//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProcessosObsReportEmpty } from "../../../Models/ProcessosObsReport";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IProcessosObsReport } from "../../Interfaces/interface.ProcessosObsReport";
import { ProcessosObsReportService } from "../../Services/ProcessosObsReport.service";
import { ProcessosObsReportApi } from "../../Apis/ApiProcessosObsReport";
import { ProcessosObsReportGridMobileComponent } from "../GridsMobile/ProcessosObsReport";
import { ProcessosObsReportGridDesktopComponent } from "../GridsDesktop/ProcessosObsReport";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProcessosObsReport } from "../../Filters/ProcessosObsReport";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ProcessosObsReportWindow from "./ProcessosObsReportWindow";

const ProcessosObsReportGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [processosobsreport, setProcessosObsReport] = useState<IProcessosObsReport[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProcessosObsReport, setSelectedProcessosObsReport] = useState<IProcessosObsReport>(ProcessosObsReportEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProcessosObsReportApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProcessosObsReport | undefined | null>(null);

    const processosobsreportService = useMemo(() => {
      return new ProcessosObsReportService(
          new ProcessosObsReportApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProcessosObsReport = async (filtro?: FilterProcessosObsReport | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await processosobsreportService.getAll(filtro ?? {} as FilterProcessosObsReport);
        setProcessosObsReport(data);
      }
      else {
        const data = await processosobsreportService.getAll(filtro ?? {} as FilterProcessosObsReport);
        setProcessosObsReport(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProcessosObsReport(currFilter);
    }, [showInc]);
  
    const handleRowClick = (processosobsreport: IProcessosObsReport) => {
      if (isMobile) {
        router.push(`/pages/processosobsreport/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${processosobsreport.id}`);
      } else {
        setSelectedProcessosObsReport(processosobsreport);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/processosobsreport/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProcessosObsReport(ProcessosObsReportEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProcessosObsReport(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const processosobsreport = e.dataItem;		
        setDeleteId(processosobsreport.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProcessosObsReport(currFilter);
            } catch {
            // falta uma mensagem de erro
            } finally {
            setDeleteId(null);
                setIsModalOpen(false);
            }
        }
    };
      
    const cancelDelete = () => {
        setDeleteId(null);
        setIsModalOpen(false);
    };

    return (
      <>
            
        {isMobile ?
           <ProcessosObsReportGridMobileComponent data={processosobsreport} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ProcessosObsReportGridDesktopComponent data={processosobsreport} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ProcessosObsReportWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProcessosObsReport={selectedProcessosObsReport}>       
        </ProcessosObsReportWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProcessosObsReportGrid;