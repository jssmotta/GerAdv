//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AgendaRepetirEmpty } from "../../../Models/AgendaRepetir";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import AgendaRepetirInc from "../Inc/AgendaRepetir";
import { IAgendaRepetir } from "../../Interfaces/interface.AgendaRepetir";
import { AgendaRepetirService } from "../../Services/AgendaRepetir.service";
import { AgendaRepetirApi } from "../../Apis/ApiAgendaRepetir";
import { AgendaRepetirGridMobileComponent } from "../GridsMobile/AgendaRepetir";
import { AgendaRepetirGridDesktopComponent } from "../GridsDesktop/AgendaRepetir";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAgendaRepetir } from "../../Filters/AgendaRepetir";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import AgendaRepetirWindow from "./AgendaRepetirWindow";

const AgendaRepetirGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [agendarepetir, setAgendaRepetir] = useState<IAgendaRepetir[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAgendaRepetir, setSelectedAgendaRepetir] = useState<IAgendaRepetir>(AgendaRepetirEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AgendaRepetirApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAgendaRepetir | undefined | null>(null);

    const agendarepetirService = useMemo(() => {
      return new AgendaRepetirService(
          new AgendaRepetirApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAgendaRepetir = async (filtro?: FilterAgendaRepetir | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await agendarepetirService.getAll(filtro ?? {} as FilterAgendaRepetir);
        setAgendaRepetir(data);
      }
      else {
        const data = await agendarepetirService.getAll(filtro ?? {} as FilterAgendaRepetir);
        setAgendaRepetir(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAgendaRepetir(currFilter);
    }, [showInc]);
  
    const handleRowClick = (agendarepetir: IAgendaRepetir) => {
      if (isMobile) {
        router.push(`/pages/agendarepetir/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${agendarepetir.id}`);
      } else {
        setSelectedAgendaRepetir(agendarepetir);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/agendarepetir/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAgendaRepetir(AgendaRepetirEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAgendaRepetir(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const agendarepetir = e.dataItem;		
        setDeleteId(agendarepetir.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAgendaRepetir(currFilter);
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
           <AgendaRepetirGridMobileComponent data={agendarepetir} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <AgendaRepetirGridDesktopComponent data={agendarepetir} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <AgendaRepetirWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAgendaRepetir={selectedAgendaRepetir}>       
        </AgendaRepetirWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AgendaRepetirGrid;