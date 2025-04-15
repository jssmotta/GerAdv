//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AgendaRecordsEmpty } from "../../../Models/AgendaRecords";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import AgendaRecordsInc from "../Inc/AgendaRecords";
import { IAgendaRecords } from "../../Interfaces/interface.AgendaRecords";
import { AgendaRecordsService } from "../../Services/AgendaRecords.service";
import { AgendaRecordsApi } from "../../Apis/ApiAgendaRecords";
import { AgendaRecordsGridMobileComponent } from "../GridsMobile/AgendaRecords";
import { AgendaRecordsGridDesktopComponent } from "../GridsDesktop/AgendaRecords";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAgendaRecords } from "../../Filters/AgendaRecords";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import AgendaRecordsWindow from "./AgendaRecordsWindow";

const AgendaRecordsGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [agendarecords, setAgendaRecords] = useState<IAgendaRecords[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAgendaRecords, setSelectedAgendaRecords] = useState<IAgendaRecords>(AgendaRecordsEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AgendaRecordsApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAgendaRecords | undefined | null>(null);

    const agendarecordsService = useMemo(() => {
      return new AgendaRecordsService(
          new AgendaRecordsApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAgendaRecords = async (filtro?: FilterAgendaRecords | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await agendarecordsService.getAll(filtro ?? {} as FilterAgendaRecords);
        setAgendaRecords(data);
      }
      else {
        const data = await agendarecordsService.getAll(filtro ?? {} as FilterAgendaRecords);
        setAgendaRecords(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAgendaRecords(currFilter);
    }, [showInc]);
  
    const handleRowClick = (agendarecords: IAgendaRecords) => {
      if (isMobile) {
        router.push(`/pages/agendarecords/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${agendarecords.id}`);
      } else {
        setSelectedAgendaRecords(agendarecords);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/agendarecords/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAgendaRecords(AgendaRecordsEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAgendaRecords(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const agendarecords = e.dataItem;		
        setDeleteId(agendarecords.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAgendaRecords(currFilter);
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
           <AgendaRecordsGridMobileComponent data={agendarecords} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <AgendaRecordsGridDesktopComponent data={agendarecords} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <AgendaRecordsWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAgendaRecords={selectedAgendaRecords}>       
        </AgendaRecordsWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AgendaRecordsGrid;