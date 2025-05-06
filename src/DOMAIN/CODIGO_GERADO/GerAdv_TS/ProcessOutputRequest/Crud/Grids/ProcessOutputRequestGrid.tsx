//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProcessOutputRequestEmpty } from "../../../Models/ProcessOutputRequest";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IProcessOutputRequest } from "../../Interfaces/interface.ProcessOutputRequest";
import { ProcessOutputRequestService } from "../../Services/ProcessOutputRequest.service";
import { ProcessOutputRequestApi } from "../../Apis/ApiProcessOutputRequest";
import { ProcessOutputRequestGridMobileComponent } from "../GridsMobile/ProcessOutputRequest";
import { ProcessOutputRequestGridDesktopComponent } from "../GridsDesktop/ProcessOutputRequest";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProcessOutputRequest } from "../../Filters/ProcessOutputRequest";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ProcessOutputRequestWindow from "./ProcessOutputRequestWindow";

const ProcessOutputRequestGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [processoutputrequest, setProcessOutputRequest] = useState<IProcessOutputRequest[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProcessOutputRequest, setSelectedProcessOutputRequest] = useState<IProcessOutputRequest>(ProcessOutputRequestEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProcessOutputRequestApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProcessOutputRequest | undefined | null>(null);

    const processoutputrequestService = useMemo(() => {
      return new ProcessOutputRequestService(
          new ProcessOutputRequestApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProcessOutputRequest = async (filtro?: FilterProcessOutputRequest | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await processoutputrequestService.getAll(filtro ?? {} as FilterProcessOutputRequest);
        setProcessOutputRequest(data);
      }
      else {
        const data = await processoutputrequestService.getAll(filtro ?? {} as FilterProcessOutputRequest);
        setProcessOutputRequest(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProcessOutputRequest(currFilter);
    }, [showInc]);
  
    const handleRowClick = (processoutputrequest: IProcessOutputRequest) => {
      if (isMobile) {
        router.push(`/pages/processoutputrequest/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${processoutputrequest.id}`);
      } else {
        setSelectedProcessOutputRequest(processoutputrequest);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/processoutputrequest/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProcessOutputRequest(ProcessOutputRequestEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProcessOutputRequest(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const processoutputrequest = e.dataItem;		
        setDeleteId(processoutputrequest.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProcessOutputRequest(currFilter);
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
           <ProcessOutputRequestGridMobileComponent data={processoutputrequest} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ProcessOutputRequestGridDesktopComponent data={processoutputrequest} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ProcessOutputRequestWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProcessOutputRequest={selectedProcessOutputRequest}>       
        </ProcessOutputRequestWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProcessOutputRequestGrid;