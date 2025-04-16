//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { HistoricoEmpty } from "../../../Models/Historico";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import HistoricoInc from "../Inc/Historico";
import { IHistorico } from "../../Interfaces/interface.Historico";
import { HistoricoService } from "../../Services/Historico.service";
import { HistoricoApi } from "../../Apis/ApiHistorico";
import { HistoricoGridMobileComponent } from "../GridsMobile/Historico";
import { HistoricoGridDesktopComponent } from "../GridsDesktop/Historico";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterHistorico } from "../../Filters/Historico";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import HistoricoWindow from "./HistoricoWindow";

const HistoricoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [historico, setHistorico] = useState<IHistorico[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedHistorico, setSelectedHistorico] = useState<IHistorico>(HistoricoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new HistoricoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterHistorico | undefined | null>(null);

    const historicoService = useMemo(() => {
      return new HistoricoService(
          new HistoricoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchHistorico = async (filtro?: FilterHistorico | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await historicoService.getAll(filtro ?? {} as FilterHistorico);
        setHistorico(data);
      }
      else {
        const data = await historicoService.getAll(filtro ?? {} as FilterHistorico);
        setHistorico(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchHistorico(currFilter);
    }, [showInc]);
  
    const handleRowClick = (historico: IHistorico) => {
      if (isMobile) {
        router.push(`/pages/historico/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${historico.id}`);
      } else {
        setSelectedHistorico(historico);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/historico/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedHistorico(HistoricoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchHistorico(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const historico = e.dataItem;		
        setDeleteId(historico.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchHistorico(currFilter);
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
           <HistoricoGridMobileComponent data={historico} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <HistoricoGridDesktopComponent data={historico} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <HistoricoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedHistorico={selectedHistorico}>       
        </HistoricoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default HistoricoGrid;