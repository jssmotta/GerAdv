//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { GUTTipoEmpty } from "../../../Models/GUTTipo";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IGUTTipo } from "../../Interfaces/interface.GUTTipo";
import { GUTTipoService } from "../../Services/GUTTipo.service";
import { GUTTipoApi } from "../../Apis/ApiGUTTipo";
import { GUTTipoGridMobileComponent } from "../GridsMobile/GUTTipo";
import { GUTTipoGridDesktopComponent } from "../GridsDesktop/GUTTipo";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterGUTTipo } from "../../Filters/GUTTipo";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import GUTTipoWindow from "./GUTTipoWindow";

const GUTTipoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [guttipo, setGUTTipo] = useState<IGUTTipo[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedGUTTipo, setSelectedGUTTipo] = useState<IGUTTipo>(GUTTipoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new GUTTipoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterGUTTipo | undefined | null>(null);

    const guttipoService = useMemo(() => {
      return new GUTTipoService(
          new GUTTipoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchGUTTipo = async (filtro?: FilterGUTTipo | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await guttipoService.getList(filtro ?? {} as FilterGUTTipo);
        setGUTTipo(data);
      }
      else {
        const data = await guttipoService.getAll(filtro ?? {} as FilterGUTTipo);
        setGUTTipo(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchGUTTipo(currFilter);
    }, [showInc]);
  
    const handleRowClick = (guttipo: IGUTTipo) => {
      if (isMobile) {
        router.push(`/pages/guttipo/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${guttipo.id}`);
      } else {
        setSelectedGUTTipo(guttipo);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/guttipo/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedGUTTipo(GUTTipoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchGUTTipo(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const guttipo = e.dataItem;		
        setDeleteId(guttipo.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchGUTTipo(currFilter);
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
           <GUTTipoGridMobileComponent data={guttipo} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <GUTTipoGridDesktopComponent data={guttipo} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <GUTTipoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedGUTTipo={selectedGUTTipo}>       
        </GUTTipoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default GUTTipoGrid;