//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { EventoPrazoAgendaEmpty } from "../../../Models/EventoPrazoAgenda";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import EventoPrazoAgendaInc from "../Inc/EventoPrazoAgenda";
import { IEventoPrazoAgenda } from "../../Interfaces/interface.EventoPrazoAgenda";
import { EventoPrazoAgendaService } from "../../Services/EventoPrazoAgenda.service";
import { EventoPrazoAgendaApi } from "../../Apis/ApiEventoPrazoAgenda";
import { EventoPrazoAgendaGridMobileComponent } from "../GridsMobile/EventoPrazoAgenda";
import { EventoPrazoAgendaGridDesktopComponent } from "../GridsDesktop/EventoPrazoAgenda";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterEventoPrazoAgenda } from "../../Filters/EventoPrazoAgenda";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import EventoPrazoAgendaWindow from "./EventoPrazoAgendaWindow";

const EventoPrazoAgendaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [eventoprazoagenda, setEventoPrazoAgenda] = useState<IEventoPrazoAgenda[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedEventoPrazoAgenda, setSelectedEventoPrazoAgenda] = useState<IEventoPrazoAgenda>(EventoPrazoAgendaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new EventoPrazoAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterEventoPrazoAgenda | undefined | null>(null);

    const eventoprazoagendaService = useMemo(() => {
      return new EventoPrazoAgendaService(
          new EventoPrazoAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchEventoPrazoAgenda = async (filtro?: FilterEventoPrazoAgenda | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await eventoprazoagendaService.getList(filtro ?? {} as FilterEventoPrazoAgenda);
        setEventoPrazoAgenda(data);
      }
      else {
        const data = await eventoprazoagendaService.getAll(filtro ?? {} as FilterEventoPrazoAgenda);
        setEventoPrazoAgenda(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchEventoPrazoAgenda(currFilter);
    }, [showInc]);
  
    const handleRowClick = (eventoprazoagenda: IEventoPrazoAgenda) => {
      if (isMobile) {
        router.push(`/pages/eventoprazoagenda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${eventoprazoagenda.id}`);
      } else {
        setSelectedEventoPrazoAgenda(eventoprazoagenda);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/eventoprazoagenda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedEventoPrazoAgenda(EventoPrazoAgendaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchEventoPrazoAgenda(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const eventoprazoagenda = e.dataItem;		
        setDeleteId(eventoprazoagenda.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchEventoPrazoAgenda(currFilter);
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
           <EventoPrazoAgendaGridMobileComponent data={eventoprazoagenda} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <EventoPrazoAgendaGridDesktopComponent data={eventoprazoagenda} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <EventoPrazoAgendaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedEventoPrazoAgenda={selectedEventoPrazoAgenda}>       
        </EventoPrazoAgendaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default EventoPrazoAgendaGrid;