//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AgendaRepetirDiasEmpty } from "../../../Models/AgendaRepetirDias";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import AgendaRepetirDiasInc from "../Inc/AgendaRepetirDias";
import { IAgendaRepetirDias } from "../../Interfaces/interface.AgendaRepetirDias";
import { AgendaRepetirDiasService } from "../../Services/AgendaRepetirDias.service";
import { AgendaRepetirDiasApi } from "../../Apis/ApiAgendaRepetirDias";
import { AgendaRepetirDiasGridMobileComponent } from "../GridsMobile/AgendaRepetirDias";
import { AgendaRepetirDiasGridDesktopComponent } from "../GridsDesktop/AgendaRepetirDias";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAgendaRepetirDias } from "../../Filters/AgendaRepetirDias";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import AgendaRepetirDiasWindow from "./AgendaRepetirDiasWindow";

const AgendaRepetirDiasGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [agendarepetirdias, setAgendaRepetirDias] = useState<IAgendaRepetirDias[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAgendaRepetirDias, setSelectedAgendaRepetirDias] = useState<IAgendaRepetirDias>(AgendaRepetirDiasEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AgendaRepetirDiasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAgendaRepetirDias | undefined | null>(null);

    const agendarepetirdiasService = useMemo(() => {
      return new AgendaRepetirDiasService(
          new AgendaRepetirDiasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAgendaRepetirDias = async (filtro?: FilterAgendaRepetirDias | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await agendarepetirdiasService.getAll(filtro ?? {} as FilterAgendaRepetirDias);
        setAgendaRepetirDias(data);
      }
      else {
        const data = await agendarepetirdiasService.getAll(filtro ?? {} as FilterAgendaRepetirDias);
        setAgendaRepetirDias(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAgendaRepetirDias(currFilter);
    }, [showInc]);
  
    const handleRowClick = (agendarepetirdias: IAgendaRepetirDias) => {
      if (isMobile) {
        router.push(`/pages/agendarepetirdias/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${agendarepetirdias.id}`);
      } else {
        setSelectedAgendaRepetirDias(agendarepetirdias);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/agendarepetirdias/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAgendaRepetirDias(AgendaRepetirDiasEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAgendaRepetirDias(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const agendarepetirdias = e.dataItem;		
        setDeleteId(agendarepetirdias.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAgendaRepetirDias(currFilter);
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
           <AgendaRepetirDiasGridMobileComponent data={agendarepetirdias} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <AgendaRepetirDiasGridDesktopComponent data={agendarepetirdias} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <AgendaRepetirDiasWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAgendaRepetirDias={selectedAgendaRepetirDias}>       
        </AgendaRepetirDiasWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AgendaRepetirDiasGrid;