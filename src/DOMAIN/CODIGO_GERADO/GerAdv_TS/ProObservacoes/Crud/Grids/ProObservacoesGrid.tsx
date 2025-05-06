//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProObservacoesEmpty } from "../../../Models/ProObservacoes";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IProObservacoes } from "../../Interfaces/interface.ProObservacoes";
import { ProObservacoesService } from "../../Services/ProObservacoes.service";
import { ProObservacoesApi } from "../../Apis/ApiProObservacoes";
import { ProObservacoesGridMobileComponent } from "../GridsMobile/ProObservacoes";
import { ProObservacoesGridDesktopComponent } from "../GridsDesktop/ProObservacoes";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProObservacoes } from "../../Filters/ProObservacoes";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ProObservacoesWindow from "./ProObservacoesWindow";

const ProObservacoesGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [proobservacoes, setProObservacoes] = useState<IProObservacoes[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProObservacoes, setSelectedProObservacoes] = useState<IProObservacoes>(ProObservacoesEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProObservacoesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProObservacoes | undefined | null>(null);

    const proobservacoesService = useMemo(() => {
      return new ProObservacoesService(
          new ProObservacoesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProObservacoes = async (filtro?: FilterProObservacoes | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await proobservacoesService.getList(filtro ?? {} as FilterProObservacoes);
        setProObservacoes(data);
      }
      else {
        const data = await proobservacoesService.getAll(filtro ?? {} as FilterProObservacoes);
        setProObservacoes(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProObservacoes(currFilter);
    }, [showInc]);
  
    const handleRowClick = (proobservacoes: IProObservacoes) => {
      if (isMobile) {
        router.push(`/pages/proobservacoes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${proobservacoes.id}`);
      } else {
        setSelectedProObservacoes(proobservacoes);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/proobservacoes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProObservacoes(ProObservacoesEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProObservacoes(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const proobservacoes = e.dataItem;		
        setDeleteId(proobservacoes.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProObservacoes(currFilter);
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
           <ProObservacoesGridMobileComponent data={proobservacoes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ProObservacoesGridDesktopComponent data={proobservacoes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ProObservacoesWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProObservacoes={selectedProObservacoes}>       
        </ProObservacoesWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProObservacoesGrid;