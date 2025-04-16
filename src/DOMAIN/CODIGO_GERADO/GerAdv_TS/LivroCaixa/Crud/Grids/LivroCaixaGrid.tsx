//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { LivroCaixaEmpty } from "../../../Models/LivroCaixa";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import LivroCaixaInc from "../Inc/LivroCaixa";
import { ILivroCaixa } from "../../Interfaces/interface.LivroCaixa";
import { LivroCaixaService } from "../../Services/LivroCaixa.service";
import { LivroCaixaApi } from "../../Apis/ApiLivroCaixa";
import { LivroCaixaGridMobileComponent } from "../GridsMobile/LivroCaixa";
import { LivroCaixaGridDesktopComponent } from "../GridsDesktop/LivroCaixa";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterLivroCaixa } from "../../Filters/LivroCaixa";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import LivroCaixaWindow from "./LivroCaixaWindow";

const LivroCaixaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [livrocaixa, setLivroCaixa] = useState<ILivroCaixa[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedLivroCaixa, setSelectedLivroCaixa] = useState<ILivroCaixa>(LivroCaixaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new LivroCaixaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterLivroCaixa | undefined | null>(null);

    const livrocaixaService = useMemo(() => {
      return new LivroCaixaService(
          new LivroCaixaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchLivroCaixa = async (filtro?: FilterLivroCaixa | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await livrocaixaService.getAll(filtro ?? {} as FilterLivroCaixa);
        setLivroCaixa(data);
      }
      else {
        const data = await livrocaixaService.getAll(filtro ?? {} as FilterLivroCaixa);
        setLivroCaixa(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchLivroCaixa(currFilter);
    }, [showInc]);
  
    const handleRowClick = (livrocaixa: ILivroCaixa) => {
      if (isMobile) {
        router.push(`/pages/livrocaixa/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${livrocaixa.id}`);
      } else {
        setSelectedLivroCaixa(livrocaixa);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/livrocaixa/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedLivroCaixa(LivroCaixaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchLivroCaixa(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const livrocaixa = e.dataItem;		
        setDeleteId(livrocaixa.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchLivroCaixa(currFilter);
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
           <LivroCaixaGridMobileComponent data={livrocaixa} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <LivroCaixaGridDesktopComponent data={livrocaixa} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <LivroCaixaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedLivroCaixa={selectedLivroCaixa}>       
        </LivroCaixaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default LivroCaixaGrid;