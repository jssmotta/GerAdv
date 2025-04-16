//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { GUTMatrizEmpty } from "../../../Models/GUTMatriz";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import GUTMatrizInc from "../Inc/GUTMatriz";
import { IGUTMatriz } from "../../Interfaces/interface.GUTMatriz";
import { GUTMatrizService } from "../../Services/GUTMatriz.service";
import { GUTMatrizApi } from "../../Apis/ApiGUTMatriz";
import { GUTMatrizGridMobileComponent } from "../GridsMobile/GUTMatriz";
import { GUTMatrizGridDesktopComponent } from "../GridsDesktop/GUTMatriz";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterGUTMatriz } from "../../Filters/GUTMatriz";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import GUTMatrizWindow from "./GUTMatrizWindow";

const GUTMatrizGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [gutmatriz, setGUTMatriz] = useState<IGUTMatriz[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedGUTMatriz, setSelectedGUTMatriz] = useState<IGUTMatriz>(GUTMatrizEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new GUTMatrizApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterGUTMatriz | undefined | null>(null);

    const gutmatrizService = useMemo(() => {
      return new GUTMatrizService(
          new GUTMatrizApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchGUTMatriz = async (filtro?: FilterGUTMatriz | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await gutmatrizService.getList(filtro ?? {} as FilterGUTMatriz);
        setGUTMatriz(data);
      }
      else {
        const data = await gutmatrizService.getAll(filtro ?? {} as FilterGUTMatriz);
        setGUTMatriz(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchGUTMatriz(currFilter);
    }, [showInc]);
  
    const handleRowClick = (gutmatriz: IGUTMatriz) => {
      if (isMobile) {
        router.push(`/pages/gutmatriz/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${gutmatriz.id}`);
      } else {
        setSelectedGUTMatriz(gutmatriz);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/gutmatriz/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedGUTMatriz(GUTMatrizEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchGUTMatriz(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const gutmatriz = e.dataItem;		
        setDeleteId(gutmatriz.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchGUTMatriz(currFilter);
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
           <GUTMatrizGridMobileComponent data={gutmatriz} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <GUTMatrizGridDesktopComponent data={gutmatriz} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <GUTMatrizWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedGUTMatriz={selectedGUTMatriz}>       
        </GUTMatrizWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default GUTMatrizGrid;