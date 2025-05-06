//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProcessOutPutIDsEmpty } from "../../../Models/ProcessOutPutIDs";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IProcessOutPutIDs } from "../../Interfaces/interface.ProcessOutPutIDs";
import { ProcessOutPutIDsService } from "../../Services/ProcessOutPutIDs.service";
import { ProcessOutPutIDsApi } from "../../Apis/ApiProcessOutPutIDs";
import { ProcessOutPutIDsGridMobileComponent } from "../GridsMobile/ProcessOutPutIDs";
import { ProcessOutPutIDsGridDesktopComponent } from "../GridsDesktop/ProcessOutPutIDs";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProcessOutPutIDs } from "../../Filters/ProcessOutPutIDs";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ProcessOutPutIDsWindow from "./ProcessOutPutIDsWindow";

const ProcessOutPutIDsGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [processoutputids, setProcessOutPutIDs] = useState<IProcessOutPutIDs[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProcessOutPutIDs, setSelectedProcessOutPutIDs] = useState<IProcessOutPutIDs>(ProcessOutPutIDsEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProcessOutPutIDsApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProcessOutPutIDs | undefined | null>(null);

    const processoutputidsService = useMemo(() => {
      return new ProcessOutPutIDsService(
          new ProcessOutPutIDsApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProcessOutPutIDs = async (filtro?: FilterProcessOutPutIDs | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await processoutputidsService.getList(filtro ?? {} as FilterProcessOutPutIDs);
        setProcessOutPutIDs(data);
      }
      else {
        const data = await processoutputidsService.getAll(filtro ?? {} as FilterProcessOutPutIDs);
        setProcessOutPutIDs(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProcessOutPutIDs(currFilter);
    }, [showInc]);
  
    const handleRowClick = (processoutputids: IProcessOutPutIDs) => {
      if (isMobile) {
        router.push(`/pages/processoutputids/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${processoutputids.id}`);
      } else {
        setSelectedProcessOutPutIDs(processoutputids);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/processoutputids/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProcessOutPutIDs(ProcessOutPutIDsEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProcessOutPutIDs(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const processoutputids = e.dataItem;		
        setDeleteId(processoutputids.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProcessOutPutIDs(currFilter);
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
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <ProcessOutPutIDsGridMobileComponent data={processoutputids} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ProcessOutPutIDsGridDesktopComponent data={processoutputids} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ProcessOutPutIDsWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProcessOutPutIDs={selectedProcessOutPutIDs}>       
        </ProcessOutPutIDsWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProcessOutPutIDsGrid;