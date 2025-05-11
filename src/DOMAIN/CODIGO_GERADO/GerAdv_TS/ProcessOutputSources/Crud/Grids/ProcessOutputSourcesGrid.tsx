//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProcessOutputSourcesEmpty } from "../../../Models/ProcessOutputSources";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IProcessOutputSources } from "../../Interfaces/interface.ProcessOutputSources";
import { ProcessOutputSourcesService } from "../../Services/ProcessOutputSources.service";
import { ProcessOutputSourcesApi } from "../../Apis/ApiProcessOutputSources";
import { ProcessOutputSourcesGridMobileComponent } from "../GridsMobile/ProcessOutputSources";
import { ProcessOutputSourcesGridDesktopComponent } from "../GridsDesktop/ProcessOutputSources";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProcessOutputSources } from "../../Filters/ProcessOutputSources";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ProcessOutputSourcesWindow from "./ProcessOutputSourcesWindow";

const ProcessOutputSourcesGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [processoutputsources, setProcessOutputSources] = useState<IProcessOutputSources[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProcessOutputSources, setSelectedProcessOutputSources] = useState<IProcessOutputSources>(ProcessOutputSourcesEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProcessOutputSourcesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProcessOutputSources | undefined | null>(null);

    const processoutputsourcesService = useMemo(() => {
      return new ProcessOutputSourcesService(
          new ProcessOutputSourcesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProcessOutputSources = async (filtro?: FilterProcessOutputSources | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await processoutputsourcesService.getList(filtro ?? {} as FilterProcessOutputSources);
        setProcessOutputSources(data);
      }
      else {
        const data = await processoutputsourcesService.getAll(filtro ?? {} as FilterProcessOutputSources);
        setProcessOutputSources(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProcessOutputSources(currFilter);
    }, [showInc]);
  
    const handleRowClick = (processoutputsources: IProcessOutputSources) => {
      if (isMobile) {
        router.push(`/pages/processoutputsources/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${processoutputsources.id}`);
      } else {
        setSelectedProcessOutputSources(processoutputsources);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/processoutputsources/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProcessOutputSources(ProcessOutputSourcesEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProcessOutputSources(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const processoutputsources = e.dataItem;		
        setDeleteId(processoutputsources.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProcessOutputSources(currFilter);
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
           <ProcessOutputSourcesGridMobileComponent data={processoutputsources} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ProcessOutputSourcesGridDesktopComponent data={processoutputsources} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ProcessOutputSourcesWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProcessOutputSources={selectedProcessOutputSources}>       
        </ProcessOutputSourcesWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProcessOutputSourcesGrid;