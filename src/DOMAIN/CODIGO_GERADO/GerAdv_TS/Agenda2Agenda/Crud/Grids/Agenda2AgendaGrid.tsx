//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { Agenda2AgendaEmpty } from "../../../Models/Agenda2Agenda";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IAgenda2Agenda } from "../../Interfaces/interface.Agenda2Agenda";
import { Agenda2AgendaService } from "../../Services/Agenda2Agenda.service";
import { Agenda2AgendaApi } from "../../Apis/ApiAgenda2Agenda";
import { Agenda2AgendaGridMobileComponent } from "../GridsMobile/Agenda2Agenda";
import { Agenda2AgendaGridDesktopComponent } from "../GridsDesktop/Agenda2Agenda";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAgenda2Agenda } from "../../Filters/Agenda2Agenda";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import Agenda2AgendaWindow from "./Agenda2AgendaWindow";

const Agenda2AgendaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [agenda2agenda, setAgenda2Agenda] = useState<IAgenda2Agenda[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAgenda2Agenda, setSelectedAgenda2Agenda] = useState<IAgenda2Agenda>(Agenda2AgendaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new Agenda2AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAgenda2Agenda | undefined | null>(null);

    const agenda2agendaService = useMemo(() => {
      return new Agenda2AgendaService(
          new Agenda2AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAgenda2Agenda = async (filtro?: FilterAgenda2Agenda | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await agenda2agendaService.getAll(filtro ?? {} as FilterAgenda2Agenda);
        setAgenda2Agenda(data);
      }
      else {
        const data = await agenda2agendaService.getAll(filtro ?? {} as FilterAgenda2Agenda);
        setAgenda2Agenda(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAgenda2Agenda(currFilter);
    }, [showInc]);
  
    const handleRowClick = (agenda2agenda: IAgenda2Agenda) => {
      if (isMobile) {
        router.push(`/pages/agenda2agenda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${agenda2agenda.id}`);
      } else {
        setSelectedAgenda2Agenda(agenda2agenda);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/agenda2agenda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAgenda2Agenda(Agenda2AgendaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAgenda2Agenda(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const agenda2agenda = e.dataItem;		
        setDeleteId(agenda2agenda.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAgenda2Agenda(currFilter);
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
           <Agenda2AgendaGridMobileComponent data={agenda2agenda} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <Agenda2AgendaGridDesktopComponent data={agenda2agenda} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <Agenda2AgendaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAgenda2Agenda={selectedAgenda2Agenda}>       
        </Agenda2AgendaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default Agenda2AgendaGrid;