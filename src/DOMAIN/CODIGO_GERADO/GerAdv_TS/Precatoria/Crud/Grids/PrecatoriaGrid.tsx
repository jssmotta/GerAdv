//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { PrecatoriaEmpty } from "../../../Models/Precatoria";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IPrecatoria } from "../../Interfaces/interface.Precatoria";
import { PrecatoriaService } from "../../Services/Precatoria.service";
import { PrecatoriaApi } from "../../Apis/ApiPrecatoria";
import { PrecatoriaGridMobileComponent } from "../GridsMobile/Precatoria";
import { PrecatoriaGridDesktopComponent } from "../GridsDesktop/Precatoria";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterPrecatoria } from "../../Filters/Precatoria";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import PrecatoriaWindow from "./PrecatoriaWindow";

const PrecatoriaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [precatoria, setPrecatoria] = useState<IPrecatoria[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedPrecatoria, setSelectedPrecatoria] = useState<IPrecatoria>(PrecatoriaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new PrecatoriaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterPrecatoria | undefined | null>(null);

    const precatoriaService = useMemo(() => {
      return new PrecatoriaService(
          new PrecatoriaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchPrecatoria = async (filtro?: FilterPrecatoria | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await precatoriaService.getAll(filtro ?? {} as FilterPrecatoria);
        setPrecatoria(data);
      }
      else {
        const data = await precatoriaService.getAll(filtro ?? {} as FilterPrecatoria);
        setPrecatoria(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchPrecatoria(currFilter);
    }, [showInc]);
  
    const handleRowClick = (precatoria: IPrecatoria) => {
      if (isMobile) {
        router.push(`/pages/precatoria/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${precatoria.id}`);
      } else {
        setSelectedPrecatoria(precatoria);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/precatoria/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedPrecatoria(PrecatoriaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchPrecatoria(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const precatoria = e.dataItem;		
        setDeleteId(precatoria.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchPrecatoria(currFilter);
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
           <PrecatoriaGridMobileComponent data={precatoria} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <PrecatoriaGridDesktopComponent data={precatoria} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <PrecatoriaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedPrecatoria={selectedPrecatoria}>       
        </PrecatoriaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default PrecatoriaGrid;