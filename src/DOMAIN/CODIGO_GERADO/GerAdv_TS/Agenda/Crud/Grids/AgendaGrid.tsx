//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AgendaEmpty } from "../../../Models/Agenda";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import AgendaInc from "../Inc/Agenda";
import { IAgenda } from "../../Interfaces/interface.Agenda";
import { AgendaService } from "../../Services/Agenda.service";
import { AgendaApi } from "../../Apis/ApiAgenda";
import { AgendaGridMobileComponent } from "../GridsMobile/Agenda";
import { AgendaGridDesktopComponent } from "../GridsDesktop/Agenda";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAgenda } from "../../Filters/Agenda";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import AgendaWindow from "./AgendaWindow";

const AgendaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [agenda, setAgenda] = useState<IAgenda[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAgenda, setSelectedAgenda] = useState<IAgenda>(AgendaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAgenda | undefined | null>(null);

    const agendaService = useMemo(() => {
      return new AgendaService(
          new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAgenda = async (filtro?: FilterAgenda | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await agendaService.getAll(filtro ?? {} as FilterAgenda);
        setAgenda(data);
      }
      else {
        const data = await agendaService.getAll(filtro ?? {} as FilterAgenda);
        setAgenda(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAgenda(currFilter);
    }, [showInc]);
  
    const handleRowClick = (agenda: IAgenda) => {
      if (isMobile) {
        router.push(`/pages/agenda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${agenda.id}`);
      } else {
        setSelectedAgenda(agenda);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/agenda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAgenda(AgendaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAgenda(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const agenda = e.dataItem;		
        setDeleteId(agenda.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAgenda(currFilter);
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
           <AgendaGridMobileComponent data={agenda} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <AgendaGridDesktopComponent data={agenda} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <AgendaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAgenda={selectedAgenda}>       
        </AgendaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AgendaGrid;