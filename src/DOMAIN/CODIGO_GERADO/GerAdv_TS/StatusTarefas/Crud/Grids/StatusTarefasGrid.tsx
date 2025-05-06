//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { StatusTarefasEmpty } from "../../../Models/StatusTarefas";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IStatusTarefas } from "../../Interfaces/interface.StatusTarefas";
import { StatusTarefasService } from "../../Services/StatusTarefas.service";
import { StatusTarefasApi } from "../../Apis/ApiStatusTarefas";
import { StatusTarefasGridMobileComponent } from "../GridsMobile/StatusTarefas";
import { StatusTarefasGridDesktopComponent } from "../GridsDesktop/StatusTarefas";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterStatusTarefas } from "../../Filters/StatusTarefas";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import StatusTarefasWindow from "./StatusTarefasWindow";

const StatusTarefasGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [statustarefas, setStatusTarefas] = useState<IStatusTarefas[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedStatusTarefas, setSelectedStatusTarefas] = useState<IStatusTarefas>(StatusTarefasEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new StatusTarefasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterStatusTarefas | undefined | null>(null);

    const statustarefasService = useMemo(() => {
      return new StatusTarefasService(
          new StatusTarefasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchStatusTarefas = async (filtro?: FilterStatusTarefas | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await statustarefasService.getList(filtro ?? {} as FilterStatusTarefas);
        setStatusTarefas(data);
      }
      else {
        const data = await statustarefasService.getAll(filtro ?? {} as FilterStatusTarefas);
        setStatusTarefas(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchStatusTarefas(currFilter);
    }, [showInc]);
  
    const handleRowClick = (statustarefas: IStatusTarefas) => {
      if (isMobile) {
        router.push(`/pages/statustarefas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${statustarefas.id}`);
      } else {
        setSelectedStatusTarefas(statustarefas);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/statustarefas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedStatusTarefas(StatusTarefasEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchStatusTarefas(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const statustarefas = e.dataItem;		
        setDeleteId(statustarefas.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchStatusTarefas(currFilter);
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
           <StatusTarefasGridMobileComponent data={statustarefas} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <StatusTarefasGridDesktopComponent data={statustarefas} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <StatusTarefasWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedStatusTarefas={selectedStatusTarefas}>       
        </StatusTarefasWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default StatusTarefasGrid;