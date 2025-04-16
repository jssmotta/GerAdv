//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProcessOutputEngineEmpty } from "../../../Models/ProcessOutputEngine";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import ProcessOutputEngineInc from "../Inc/ProcessOutputEngine";
import { IProcessOutputEngine } from "../../Interfaces/interface.ProcessOutputEngine";
import { ProcessOutputEngineService } from "../../Services/ProcessOutputEngine.service";
import { ProcessOutputEngineApi } from "../../Apis/ApiProcessOutputEngine";
import { ProcessOutputEngineGridMobileComponent } from "../GridsMobile/ProcessOutputEngine";
import { ProcessOutputEngineGridDesktopComponent } from "../GridsDesktop/ProcessOutputEngine";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProcessOutputEngine } from "../../Filters/ProcessOutputEngine";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import ProcessOutputEngineWindow from "./ProcessOutputEngineWindow";

const ProcessOutputEngineGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [processoutputengine, setProcessOutputEngine] = useState<IProcessOutputEngine[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProcessOutputEngine, setSelectedProcessOutputEngine] = useState<IProcessOutputEngine>(ProcessOutputEngineEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProcessOutputEngineApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProcessOutputEngine | undefined | null>(null);

    const processoutputengineService = useMemo(() => {
      return new ProcessOutputEngineService(
          new ProcessOutputEngineApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProcessOutputEngine = async (filtro?: FilterProcessOutputEngine | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await processoutputengineService.getList(filtro ?? {} as FilterProcessOutputEngine);
        setProcessOutputEngine(data);
      }
      else {
        const data = await processoutputengineService.getAll(filtro ?? {} as FilterProcessOutputEngine);
        setProcessOutputEngine(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProcessOutputEngine(currFilter);
    }, [showInc]);
  
    const handleRowClick = (processoutputengine: IProcessOutputEngine) => {
      if (isMobile) {
        router.push(`/pages/processoutputengine/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${processoutputengine.id}`);
      } else {
        setSelectedProcessOutputEngine(processoutputengine);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/processoutputengine/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProcessOutputEngine(ProcessOutputEngineEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProcessOutputEngine(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const processoutputengine = e.dataItem;		
        setDeleteId(processoutputengine.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProcessOutputEngine(currFilter);
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
           <ProcessOutputEngineGridMobileComponent data={processoutputengine} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <ProcessOutputEngineGridDesktopComponent data={processoutputengine} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <ProcessOutputEngineWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProcessOutputEngine={selectedProcessOutputEngine}>       
        </ProcessOutputEngineWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProcessOutputEngineGrid;