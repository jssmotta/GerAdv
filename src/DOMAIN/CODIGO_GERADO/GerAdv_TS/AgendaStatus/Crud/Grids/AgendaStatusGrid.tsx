//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AgendaStatusEmpty } from "../../../Models/AgendaStatus";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import AgendaStatusInc from "../Inc/AgendaStatus";
import { IAgendaStatus } from "../../Interfaces/interface.AgendaStatus";
import { AgendaStatusService } from "../../Services/AgendaStatus.service";
import { AgendaStatusApi } from "../../Apis/ApiAgendaStatus";
import { AgendaStatusGridMobileComponent } from "../GridsMobile/AgendaStatus";
import { AgendaStatusGridDesktopComponent } from "../GridsDesktop/AgendaStatus";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAgendaStatus } from "../../Filters/AgendaStatus";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import AgendaStatusWindow from "./AgendaStatusWindow";

const AgendaStatusGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [agendastatus, setAgendaStatus] = useState<IAgendaStatus[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAgendaStatus, setSelectedAgendaStatus] = useState<IAgendaStatus>(AgendaStatusEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AgendaStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAgendaStatus | undefined | null>(null);

    const agendastatusService = useMemo(() => {
      return new AgendaStatusService(
          new AgendaStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAgendaStatus = async (filtro?: FilterAgendaStatus | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await agendastatusService.getAll(filtro ?? {} as FilterAgendaStatus);
        setAgendaStatus(data);
      }
      else {
        const data = await agendastatusService.getAll(filtro ?? {} as FilterAgendaStatus);
        setAgendaStatus(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAgendaStatus(currFilter);
    }, [showInc]);
  
    const handleRowClick = (agendastatus: IAgendaStatus) => {
      if (isMobile) {
        router.push(`/pages/agendastatus/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${agendastatus.id}`);
      } else {
        setSelectedAgendaStatus(agendastatus);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/agendastatus/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAgendaStatus(AgendaStatusEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAgendaStatus(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const agendastatus = e.dataItem;		
        setDeleteId(agendastatus.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAgendaStatus(currFilter);
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
           <AgendaStatusGridMobileComponent data={agendastatus} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <AgendaStatusGridDesktopComponent data={agendastatus} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <AgendaStatusWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAgendaStatus={selectedAgendaStatus}>       
        </AgendaStatusWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AgendaStatusGrid;