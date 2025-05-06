//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AnexamentoRegistrosEmpty } from "../../../Models/AnexamentoRegistros";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IAnexamentoRegistros } from "../../Interfaces/interface.AnexamentoRegistros";
import { AnexamentoRegistrosService } from "../../Services/AnexamentoRegistros.service";
import { AnexamentoRegistrosApi } from "../../Apis/ApiAnexamentoRegistros";
import { AnexamentoRegistrosGridMobileComponent } from "../GridsMobile/AnexamentoRegistros";
import { AnexamentoRegistrosGridDesktopComponent } from "../GridsDesktop/AnexamentoRegistros";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAnexamentoRegistros } from "../../Filters/AnexamentoRegistros";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import AnexamentoRegistrosWindow from "./AnexamentoRegistrosWindow";

const AnexamentoRegistrosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [anexamentoregistros, setAnexamentoRegistros] = useState<IAnexamentoRegistros[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAnexamentoRegistros, setSelectedAnexamentoRegistros] = useState<IAnexamentoRegistros>(AnexamentoRegistrosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AnexamentoRegistrosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAnexamentoRegistros | undefined | null>(null);

    const anexamentoregistrosService = useMemo(() => {
      return new AnexamentoRegistrosService(
          new AnexamentoRegistrosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAnexamentoRegistros = async (filtro?: FilterAnexamentoRegistros | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await anexamentoregistrosService.getAll(filtro ?? {} as FilterAnexamentoRegistros);
        setAnexamentoRegistros(data);
      }
      else {
        const data = await anexamentoregistrosService.getAll(filtro ?? {} as FilterAnexamentoRegistros);
        setAnexamentoRegistros(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAnexamentoRegistros(currFilter);
    }, [showInc]);
  
    const handleRowClick = (anexamentoregistros: IAnexamentoRegistros) => {
      if (isMobile) {
        router.push(`/pages/anexamentoregistros/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${anexamentoregistros.id}`);
      } else {
        setSelectedAnexamentoRegistros(anexamentoregistros);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/anexamentoregistros/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAnexamentoRegistros(AnexamentoRegistrosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAnexamentoRegistros(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const anexamentoregistros = e.dataItem;		
        setDeleteId(anexamentoregistros.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAnexamentoRegistros(currFilter);
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
           <AnexamentoRegistrosGridMobileComponent data={anexamentoregistros} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <AnexamentoRegistrosGridDesktopComponent data={anexamentoregistros} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <AnexamentoRegistrosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAnexamentoRegistros={selectedAnexamentoRegistros}>       
        </AnexamentoRegistrosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AnexamentoRegistrosGrid;