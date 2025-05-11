//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { PreClientesEmpty } from "../../../Models/PreClientes";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IPreClientes } from "../../Interfaces/interface.PreClientes";
import { PreClientesService } from "../../Services/PreClientes.service";
import { PreClientesApi } from "../../Apis/ApiPreClientes";
import { PreClientesGridMobileComponent } from "../GridsMobile/PreClientes";
import { PreClientesGridDesktopComponent } from "../GridsDesktop/PreClientes";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterPreClientes } from "../../Filters/PreClientes";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import PreClientesWindow from "./PreClientesWindow";

const PreClientesGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [preclientes, setPreClientes] = useState<IPreClientes[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedPreClientes, setSelectedPreClientes] = useState<IPreClientes>(PreClientesEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new PreClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterPreClientes | undefined | null>(null);

    const preclientesService = useMemo(() => {
      return new PreClientesService(
          new PreClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchPreClientes = async (filtro?: FilterPreClientes | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await preclientesService.getList(filtro ?? {} as FilterPreClientes);
        setPreClientes(data);
      }
      else {
        const data = await preclientesService.getAll(filtro ?? {} as FilterPreClientes);
        setPreClientes(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchPreClientes(currFilter);
    }, [showInc]);
  
    const handleRowClick = (preclientes: IPreClientes) => {
      if (isMobile) {
        router.push(`/pages/preclientes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${preclientes.id}`);
      } else {
        setSelectedPreClientes(preclientes);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/preclientes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedPreClientes(PreClientesEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchPreClientes(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const preclientes = e.dataItem;		
        setDeleteId(preclientes.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchPreClientes(currFilter);
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
           <PreClientesGridMobileComponent data={preclientes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <PreClientesGridDesktopComponent data={preclientes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <PreClientesWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedPreClientes={selectedPreClientes}>       
        </PreClientesWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default PreClientesGrid;