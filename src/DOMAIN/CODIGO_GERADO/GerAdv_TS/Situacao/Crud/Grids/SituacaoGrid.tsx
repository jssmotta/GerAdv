//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { SituacaoEmpty } from "../../../Models/Situacao";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { ISituacao } from "../../Interfaces/interface.Situacao";
import { SituacaoService } from "../../Services/Situacao.service";
import { SituacaoApi } from "../../Apis/ApiSituacao";
import { SituacaoGridMobileComponent } from "../GridsMobile/Situacao";
import { SituacaoGridDesktopComponent } from "../GridsDesktop/Situacao";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterSituacao } from "../../Filters/Situacao";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import SituacaoWindow from "./SituacaoWindow";

const SituacaoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [situacao, setSituacao] = useState<ISituacao[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedSituacao, setSelectedSituacao] = useState<ISituacao>(SituacaoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new SituacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterSituacao | undefined | null>(null);

    const situacaoService = useMemo(() => {
      return new SituacaoService(
          new SituacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchSituacao = async (filtro?: FilterSituacao | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await situacaoService.getAll(filtro ?? {} as FilterSituacao);
        setSituacao(data);
      }
      else {
        const data = await situacaoService.getAll(filtro ?? {} as FilterSituacao);
        setSituacao(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchSituacao(currFilter);
    }, [showInc]);
  
    const handleRowClick = (situacao: ISituacao) => {
      if (isMobile) {
        router.push(`/pages/situacao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${situacao.id}`);
      } else {
        setSelectedSituacao(situacao);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/situacao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedSituacao(SituacaoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchSituacao(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const situacao = e.dataItem;		
        setDeleteId(situacao.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchSituacao(currFilter);
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
           <SituacaoGridMobileComponent data={situacao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <SituacaoGridDesktopComponent data={situacao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <SituacaoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedSituacao={selectedSituacao}>       
        </SituacaoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default SituacaoGrid;