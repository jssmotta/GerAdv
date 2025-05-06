//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ProPartesEmpty } from "../../../Models/ProPartes";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IProPartes } from "../../Interfaces/interface.ProPartes";
import { ProPartesService } from "../../Services/ProPartes.service";
import { ProPartesApi } from "../../Apis/ApiProPartes";
import { ProPartesGridMobileComponent } from "../GridsMobile/ProPartes";
import { ProPartesGridDesktopComponent } from "../GridsDesktop/ProPartes";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterProPartes } from "../../Filters/ProPartes";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ProPartesWindow from "./ProPartesWindow";

const ProPartesGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [propartes, setProPartes] = useState<IProPartes[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedProPartes, setSelectedProPartes] = useState<IProPartes>(ProPartesEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ProPartesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterProPartes | undefined | null>(null);

    const propartesService = useMemo(() => {
      return new ProPartesService(
          new ProPartesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchProPartes = async (filtro?: FilterProPartes | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await propartesService.getAll(filtro ?? {} as FilterProPartes);
        setProPartes(data);
      }
      else {
        const data = await propartesService.getAll(filtro ?? {} as FilterProPartes);
        setProPartes(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchProPartes(currFilter);
    }, [showInc]);
  
    const handleRowClick = (propartes: IProPartes) => {
      if (isMobile) {
        router.push(`/pages/propartes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${propartes.id}`);
      } else {
        setSelectedProPartes(propartes);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/propartes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedProPartes(ProPartesEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchProPartes(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const propartes = e.dataItem;		
        setDeleteId(propartes.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchProPartes(currFilter);
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
           <ProPartesGridMobileComponent data={propartes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ProPartesGridDesktopComponent data={propartes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ProPartesWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedProPartes={selectedProPartes}>       
        </ProPartesWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ProPartesGrid;