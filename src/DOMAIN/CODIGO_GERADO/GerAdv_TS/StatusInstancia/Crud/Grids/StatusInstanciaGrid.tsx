//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { StatusInstanciaEmpty } from "../../../Models/StatusInstancia";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import StatusInstanciaInc from "../Inc/StatusInstancia";
import { IStatusInstancia } from "../../Interfaces/interface.StatusInstancia";
import { StatusInstanciaService } from "../../Services/StatusInstancia.service";
import { StatusInstanciaApi } from "../../Apis/ApiStatusInstancia";
import { StatusInstanciaGridMobileComponent } from "../GridsMobile/StatusInstancia";
import { StatusInstanciaGridDesktopComponent } from "../GridsDesktop/StatusInstancia";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterStatusInstancia } from "../../Filters/StatusInstancia";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import StatusInstanciaWindow from "./StatusInstanciaWindow";

const StatusInstanciaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [statusinstancia, setStatusInstancia] = useState<IStatusInstancia[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedStatusInstancia, setSelectedStatusInstancia] = useState<IStatusInstancia>(StatusInstanciaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new StatusInstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterStatusInstancia | undefined | null>(null);

    const statusinstanciaService = useMemo(() => {
      return new StatusInstanciaService(
          new StatusInstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchStatusInstancia = async (filtro?: FilterStatusInstancia | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await statusinstanciaService.getList(filtro ?? {} as FilterStatusInstancia);
        setStatusInstancia(data);
      }
      else {
        const data = await statusinstanciaService.getAll(filtro ?? {} as FilterStatusInstancia);
        setStatusInstancia(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchStatusInstancia(currFilter);
    }, [showInc]);
  
    const handleRowClick = (statusinstancia: IStatusInstancia) => {
      if (isMobile) {
        router.push(`/pages/statusinstancia/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${statusinstancia.id}`);
      } else {
        setSelectedStatusInstancia(statusinstancia);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/statusinstancia/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedStatusInstancia(StatusInstanciaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchStatusInstancia(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const statusinstancia = e.dataItem;		
        setDeleteId(statusinstancia.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchStatusInstancia(currFilter);
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
           <StatusInstanciaGridMobileComponent data={statusinstancia} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <StatusInstanciaGridDesktopComponent data={statusinstancia} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <StatusInstanciaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedStatusInstancia={selectedStatusInstancia}>       
        </StatusInstanciaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default StatusInstanciaGrid;