//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { DadosProcuracaoEmpty } from "../../../Models/DadosProcuracao";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import DadosProcuracaoInc from "../Inc/DadosProcuracao";
import { IDadosProcuracao } from "../../Interfaces/interface.DadosProcuracao";
import { DadosProcuracaoService } from "../../Services/DadosProcuracao.service";
import { DadosProcuracaoApi } from "../../Apis/ApiDadosProcuracao";
import { DadosProcuracaoGridMobileComponent } from "../GridsMobile/DadosProcuracao";
import { DadosProcuracaoGridDesktopComponent } from "../GridsDesktop/DadosProcuracao";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterDadosProcuracao } from "../../Filters/DadosProcuracao";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import DadosProcuracaoWindow from "./DadosProcuracaoWindow";

const DadosProcuracaoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [dadosprocuracao, setDadosProcuracao] = useState<IDadosProcuracao[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedDadosProcuracao, setSelectedDadosProcuracao] = useState<IDadosProcuracao>(DadosProcuracaoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new DadosProcuracaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterDadosProcuracao | undefined | null>(null);

    const dadosprocuracaoService = useMemo(() => {
      return new DadosProcuracaoService(
          new DadosProcuracaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchDadosProcuracao = async (filtro?: FilterDadosProcuracao | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await dadosprocuracaoService.getAll(filtro ?? {} as FilterDadosProcuracao);
        setDadosProcuracao(data);
      }
      else {
        const data = await dadosprocuracaoService.getAll(filtro ?? {} as FilterDadosProcuracao);
        setDadosProcuracao(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchDadosProcuracao(currFilter);
    }, [showInc]);
  
    const handleRowClick = (dadosprocuracao: IDadosProcuracao) => {
      if (isMobile) {
        router.push(`/pages/dadosprocuracao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${dadosprocuracao.id}`);
      } else {
        setSelectedDadosProcuracao(dadosprocuracao);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/dadosprocuracao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedDadosProcuracao(DadosProcuracaoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchDadosProcuracao(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const dadosprocuracao = e.dataItem;		
        setDeleteId(dadosprocuracao.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchDadosProcuracao(currFilter);
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
           <DadosProcuracaoGridMobileComponent data={dadosprocuracao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <DadosProcuracaoGridDesktopComponent data={dadosprocuracao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <DadosProcuracaoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedDadosProcuracao={selectedDadosProcuracao}>       
        </DadosProcuracaoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default DadosProcuracaoGrid;