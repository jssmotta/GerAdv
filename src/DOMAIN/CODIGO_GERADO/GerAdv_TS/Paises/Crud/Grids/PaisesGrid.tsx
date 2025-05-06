//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { PaisesEmpty } from "../../../Models/Paises";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IPaises } from "../../Interfaces/interface.Paises";
import { PaisesService } from "../../Services/Paises.service";
import { PaisesApi } from "../../Apis/ApiPaises";
import { PaisesGridMobileComponent } from "../GridsMobile/Paises";
import { PaisesGridDesktopComponent } from "../GridsDesktop/Paises";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterPaises } from "../../Filters/Paises";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import PaisesWindow from "./PaisesWindow";

const PaisesGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [paises, setPaises] = useState<IPaises[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedPaises, setSelectedPaises] = useState<IPaises>(PaisesEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new PaisesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterPaises | undefined | null>(null);

    const paisesService = useMemo(() => {
      return new PaisesService(
          new PaisesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchPaises = async (filtro?: FilterPaises | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await paisesService.getList(filtro ?? {} as FilterPaises);
        setPaises(data);
      }
      else {
        const data = await paisesService.getAll(filtro ?? {} as FilterPaises);
        setPaises(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchPaises(currFilter);
    }, [showInc]);
  
    const handleRowClick = (paises: IPaises) => {
      if (isMobile) {
        router.push(`/pages/paises/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${paises.id}`);
      } else {
        setSelectedPaises(paises);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/paises/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedPaises(PaisesEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchPaises(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const paises = e.dataItem;		
        setDeleteId(paises.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchPaises(currFilter);
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
           <PaisesGridMobileComponent data={paises} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <PaisesGridDesktopComponent data={paises} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <PaisesWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedPaises={selectedPaises}>       
        </PaisesWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default PaisesGrid;