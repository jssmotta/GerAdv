//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { GUTPeriodicidadeEmpty } from "../../../Models/GUTPeriodicidade";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import GUTPeriodicidadeInc from "../Inc/GUTPeriodicidade";
import { IGUTPeriodicidade } from "../../Interfaces/interface.GUTPeriodicidade";
import { GUTPeriodicidadeService } from "../../Services/GUTPeriodicidade.service";
import { GUTPeriodicidadeApi } from "../../Apis/ApiGUTPeriodicidade";
import { GUTPeriodicidadeGridMobileComponent } from "../GridsMobile/GUTPeriodicidade";
import { GUTPeriodicidadeGridDesktopComponent } from "../GridsDesktop/GUTPeriodicidade";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterGUTPeriodicidade } from "../../Filters/GUTPeriodicidade";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import GUTPeriodicidadeWindow from "./GUTPeriodicidadeWindow";

const GUTPeriodicidadeGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [gutperiodicidade, setGUTPeriodicidade] = useState<IGUTPeriodicidade[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedGUTPeriodicidade, setSelectedGUTPeriodicidade] = useState<IGUTPeriodicidade>(GUTPeriodicidadeEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new GUTPeriodicidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterGUTPeriodicidade | undefined | null>(null);

    const gutperiodicidadeService = useMemo(() => {
      return new GUTPeriodicidadeService(
          new GUTPeriodicidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchGUTPeriodicidade = async (filtro?: FilterGUTPeriodicidade | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await gutperiodicidadeService.getList(filtro ?? {} as FilterGUTPeriodicidade);
        setGUTPeriodicidade(data);
      }
      else {
        const data = await gutperiodicidadeService.getAll(filtro ?? {} as FilterGUTPeriodicidade);
        setGUTPeriodicidade(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchGUTPeriodicidade(currFilter);
    }, [showInc]);
  
    const handleRowClick = (gutperiodicidade: IGUTPeriodicidade) => {
      if (isMobile) {
        router.push(`/pages/gutperiodicidade/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${gutperiodicidade.id}`);
      } else {
        setSelectedGUTPeriodicidade(gutperiodicidade);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/gutperiodicidade/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedGUTPeriodicidade(GUTPeriodicidadeEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchGUTPeriodicidade(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const gutperiodicidade = e.dataItem;		
        setDeleteId(gutperiodicidade.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchGUTPeriodicidade(currFilter);
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
           <GUTPeriodicidadeGridMobileComponent data={gutperiodicidade} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <GUTPeriodicidadeGridDesktopComponent data={gutperiodicidade} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <GUTPeriodicidadeWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedGUTPeriodicidade={selectedGUTPeriodicidade}>       
        </GUTPeriodicidadeWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default GUTPeriodicidadeGrid;