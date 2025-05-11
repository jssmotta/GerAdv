//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { LigacoesEmpty } from "../../../Models/Ligacoes";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { ILigacoes } from "../../Interfaces/interface.Ligacoes";
import { LigacoesService } from "../../Services/Ligacoes.service";
import { LigacoesApi } from "../../Apis/ApiLigacoes";
import { LigacoesGridMobileComponent } from "../GridsMobile/Ligacoes";
import { LigacoesGridDesktopComponent } from "../GridsDesktop/Ligacoes";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterLigacoes } from "../../Filters/Ligacoes";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import LigacoesWindow from "./LigacoesWindow";

const LigacoesGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [ligacoes, setLigacoes] = useState<ILigacoes[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedLigacoes, setSelectedLigacoes] = useState<ILigacoes>(LigacoesEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new LigacoesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterLigacoes | undefined | null>(null);

    const ligacoesService = useMemo(() => {
      return new LigacoesService(
          new LigacoesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchLigacoes = async (filtro?: FilterLigacoes | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await ligacoesService.getList(filtro ?? {} as FilterLigacoes);
        setLigacoes(data);
      }
      else {
        const data = await ligacoesService.getAll(filtro ?? {} as FilterLigacoes);
        setLigacoes(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchLigacoes(currFilter);
    }, [showInc]);
  
    const handleRowClick = (ligacoes: ILigacoes) => {
      if (isMobile) {
        router.push(`/pages/ligacoes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${ligacoes.id}`);
      } else {
        setSelectedLigacoes(ligacoes);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/ligacoes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedLigacoes(LigacoesEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchLigacoes(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const ligacoes = e.dataItem;		
        setDeleteId(ligacoes.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchLigacoes(currFilter);
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
           <LigacoesGridMobileComponent data={ligacoes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <LigacoesGridDesktopComponent data={ligacoes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <LigacoesWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedLigacoes={selectedLigacoes}>       
        </LigacoesWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default LigacoesGrid;