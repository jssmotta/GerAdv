//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AreasJusticaEmpty } from "../../../Models/AreasJustica";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IAreasJustica } from "../../Interfaces/interface.AreasJustica";
import { AreasJusticaService } from "../../Services/AreasJustica.service";
import { AreasJusticaApi } from "../../Apis/ApiAreasJustica";
import { AreasJusticaGridMobileComponent } from "../GridsMobile/AreasJustica";
import { AreasJusticaGridDesktopComponent } from "../GridsDesktop/AreasJustica";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAreasJustica } from "../../Filters/AreasJustica";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import AreasJusticaWindow from "./AreasJusticaWindow";

const AreasJusticaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [areasjustica, setAreasJustica] = useState<IAreasJustica[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAreasJustica, setSelectedAreasJustica] = useState<IAreasJustica>(AreasJusticaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AreasJusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAreasJustica | undefined | null>(null);

    const areasjusticaService = useMemo(() => {
      return new AreasJusticaService(
          new AreasJusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAreasJustica = async (filtro?: FilterAreasJustica | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await areasjusticaService.getAll(filtro ?? {} as FilterAreasJustica);
        setAreasJustica(data);
      }
      else {
        const data = await areasjusticaService.getAll(filtro ?? {} as FilterAreasJustica);
        setAreasJustica(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAreasJustica(currFilter);
    }, [showInc]);
  
    const handleRowClick = (areasjustica: IAreasJustica) => {
      if (isMobile) {
        router.push(`/pages/areasjustica/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${areasjustica.id}`);
      } else {
        setSelectedAreasJustica(areasjustica);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/areasjustica/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAreasJustica(AreasJusticaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAreasJustica(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const areasjustica = e.dataItem;		
        setDeleteId(areasjustica.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAreasJustica(currFilter);
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
           <AreasJusticaGridMobileComponent data={areasjustica} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <AreasJusticaGridDesktopComponent data={areasjustica} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <AreasJusticaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAreasJustica={selectedAreasJustica}>       
        </AreasJusticaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AreasJusticaGrid;