//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AgendaFinanceiroEmpty } from "../../../Models/AgendaFinanceiro";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IAgendaFinanceiro } from "../../Interfaces/interface.AgendaFinanceiro";
import { AgendaFinanceiroService } from "../../Services/AgendaFinanceiro.service";
import { AgendaFinanceiroApi } from "../../Apis/ApiAgendaFinanceiro";
import { AgendaFinanceiroGridMobileComponent } from "../GridsMobile/AgendaFinanceiro";
import { AgendaFinanceiroGridDesktopComponent } from "../GridsDesktop/AgendaFinanceiro";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAgendaFinanceiro } from "../../Filters/AgendaFinanceiro";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import AgendaFinanceiroWindow from "./AgendaFinanceiroWindow";

const AgendaFinanceiroGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [agendafinanceiro, setAgendaFinanceiro] = useState<IAgendaFinanceiro[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAgendaFinanceiro, setSelectedAgendaFinanceiro] = useState<IAgendaFinanceiro>(AgendaFinanceiroEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AgendaFinanceiroApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAgendaFinanceiro | undefined | null>(null);

    const agendafinanceiroService = useMemo(() => {
      return new AgendaFinanceiroService(
          new AgendaFinanceiroApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAgendaFinanceiro = async (filtro?: FilterAgendaFinanceiro | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await agendafinanceiroService.getAll(filtro ?? {} as FilterAgendaFinanceiro);
        setAgendaFinanceiro(data);
      }
      else {
        const data = await agendafinanceiroService.getAll(filtro ?? {} as FilterAgendaFinanceiro);
        setAgendaFinanceiro(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAgendaFinanceiro(currFilter);
    }, [showInc]);
  
    const handleRowClick = (agendafinanceiro: IAgendaFinanceiro) => {
      if (isMobile) {
        router.push(`/pages/agendafinanceiro/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${agendafinanceiro.id}`);
      } else {
        setSelectedAgendaFinanceiro(agendafinanceiro);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/agendafinanceiro/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAgendaFinanceiro(AgendaFinanceiroEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAgendaFinanceiro(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const agendafinanceiro = e.dataItem;		
        setDeleteId(agendafinanceiro.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAgendaFinanceiro(currFilter);
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
           <AgendaFinanceiroGridMobileComponent data={agendafinanceiro} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <AgendaFinanceiroGridDesktopComponent data={agendafinanceiro} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <AgendaFinanceiroWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAgendaFinanceiro={selectedAgendaFinanceiro}>       
        </AgendaFinanceiroWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AgendaFinanceiroGrid;