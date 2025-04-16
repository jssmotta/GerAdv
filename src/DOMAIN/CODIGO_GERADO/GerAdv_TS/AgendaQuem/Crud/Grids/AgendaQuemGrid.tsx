//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AgendaQuemEmpty } from "../../../Models/AgendaQuem";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import AgendaQuemInc from "../Inc/AgendaQuem";
import { IAgendaQuem } from "../../Interfaces/interface.AgendaQuem";
import { AgendaQuemService } from "../../Services/AgendaQuem.service";
import { AgendaQuemApi } from "../../Apis/ApiAgendaQuem";
import { AgendaQuemGridMobileComponent } from "../GridsMobile/AgendaQuem";
import { AgendaQuemGridDesktopComponent } from "../GridsDesktop/AgendaQuem";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAgendaQuem } from "../../Filters/AgendaQuem";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import AgendaQuemWindow from "./AgendaQuemWindow";

const AgendaQuemGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [agendaquem, setAgendaQuem] = useState<IAgendaQuem[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAgendaQuem, setSelectedAgendaQuem] = useState<IAgendaQuem>(AgendaQuemEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AgendaQuemApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAgendaQuem | undefined | null>(null);

    const agendaquemService = useMemo(() => {
      return new AgendaQuemService(
          new AgendaQuemApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAgendaQuem = async (filtro?: FilterAgendaQuem | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await agendaquemService.getAll(filtro ?? {} as FilterAgendaQuem);
        setAgendaQuem(data);
      }
      else {
        const data = await agendaquemService.getAll(filtro ?? {} as FilterAgendaQuem);
        setAgendaQuem(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAgendaQuem(currFilter);
    }, [showInc]);
  
    const handleRowClick = (agendaquem: IAgendaQuem) => {
      if (isMobile) {
        router.push(`/pages/agendaquem/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${agendaquem.id}`);
      } else {
        setSelectedAgendaQuem(agendaquem);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/agendaquem/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAgendaQuem(AgendaQuemEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAgendaQuem(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const agendaquem = e.dataItem;		
        setDeleteId(agendaquem.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAgendaQuem(currFilter);
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
           <AgendaQuemGridMobileComponent data={agendaquem} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <AgendaQuemGridDesktopComponent data={agendaquem} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <AgendaQuemWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAgendaQuem={selectedAgendaQuem}>       
        </AgendaQuemWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AgendaQuemGrid;