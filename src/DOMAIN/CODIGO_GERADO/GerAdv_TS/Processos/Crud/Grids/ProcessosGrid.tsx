//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProcessosEmpty } from "../../../Models/Processos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import ProcessosInc from "../Inc/Processos";
import { IProcessos } from "../../Interfaces/interface.Processos";
import { ProcessosService } from "../../Services/Processos.service";
import { ProcessosApi } from "../../Apis/ApiProcessos";
import { ProcessosGridMobileComponent } from "../GridsMobile/Processos";
import { ProcessosGridDesktopComponent } from "../GridsDesktop/Processos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProcessos } from "../../Filters/Processos";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import ProcessosWindow from "./ProcessosWindow";

const ProcessosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [processos, setProcessos] = useState<IProcessos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProcessos, setSelectedProcessos] = useState<IProcessos>(ProcessosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProcessos | undefined | null>(null);

    const processosService = useMemo(() => {
      return new ProcessosService(
          new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProcessos = async (filtro?: FilterProcessos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await processosService.getList(filtro ?? {} as FilterProcessos);
        setProcessos(data);
      }
      else {
        const data = await processosService.getAll(filtro ?? {} as FilterProcessos);
        setProcessos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProcessos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (processos: IProcessos) => {
      if (isMobile) {
        router.push(`/pages/processos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${processos.id}`);
      } else {
        setSelectedProcessos(processos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/processos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProcessos(ProcessosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProcessos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const processos = e.dataItem;		
        setDeleteId(processos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProcessos(currFilter);
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
           <ProcessosGridMobileComponent data={processos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <ProcessosGridDesktopComponent data={processos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <ProcessosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProcessos={selectedProcessos}>       
        </ProcessosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProcessosGrid;