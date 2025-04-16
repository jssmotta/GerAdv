//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProcessosParadosEmpty } from "../../../Models/ProcessosParados";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import ProcessosParadosInc from "../Inc/ProcessosParados";
import { IProcessosParados } from "../../Interfaces/interface.ProcessosParados";
import { ProcessosParadosService } from "../../Services/ProcessosParados.service";
import { ProcessosParadosApi } from "../../Apis/ApiProcessosParados";
import { ProcessosParadosGridMobileComponent } from "../GridsMobile/ProcessosParados";
import { ProcessosParadosGridDesktopComponent } from "../GridsDesktop/ProcessosParados";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProcessosParados } from "../../Filters/ProcessosParados";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import ProcessosParadosWindow from "./ProcessosParadosWindow";

const ProcessosParadosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [processosparados, setProcessosParados] = useState<IProcessosParados[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProcessosParados, setSelectedProcessosParados] = useState<IProcessosParados>(ProcessosParadosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProcessosParadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProcessosParados | undefined | null>(null);

    const processosparadosService = useMemo(() => {
      return new ProcessosParadosService(
          new ProcessosParadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProcessosParados = async (filtro?: FilterProcessosParados | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await processosparadosService.getAll(filtro ?? {} as FilterProcessosParados);
        setProcessosParados(data);
      }
      else {
        const data = await processosparadosService.getAll(filtro ?? {} as FilterProcessosParados);
        setProcessosParados(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProcessosParados(currFilter);
    }, [showInc]);
  
    const handleRowClick = (processosparados: IProcessosParados) => {
      if (isMobile) {
        router.push(`/pages/processosparados/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${processosparados.id}`);
      } else {
        setSelectedProcessosParados(processosparados);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/processosparados/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProcessosParados(ProcessosParadosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProcessosParados(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const processosparados = e.dataItem;		
        setDeleteId(processosparados.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProcessosParados(currFilter);
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
           <ProcessosParadosGridMobileComponent data={processosparados} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <ProcessosParadosGridDesktopComponent data={processosparados} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <ProcessosParadosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProcessosParados={selectedProcessosParados}>       
        </ProcessosParadosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProcessosParadosGrid;