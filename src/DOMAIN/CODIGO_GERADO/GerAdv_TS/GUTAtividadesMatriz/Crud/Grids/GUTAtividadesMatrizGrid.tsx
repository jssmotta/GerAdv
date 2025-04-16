//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { GUTAtividadesMatrizEmpty } from "../../../Models/GUTAtividadesMatriz";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import GUTAtividadesMatrizInc from "../Inc/GUTAtividadesMatriz";
import { IGUTAtividadesMatriz } from "../../Interfaces/interface.GUTAtividadesMatriz";
import { GUTAtividadesMatrizService } from "../../Services/GUTAtividadesMatriz.service";
import { GUTAtividadesMatrizApi } from "../../Apis/ApiGUTAtividadesMatriz";
import { GUTAtividadesMatrizGridMobileComponent } from "../GridsMobile/GUTAtividadesMatriz";
import { GUTAtividadesMatrizGridDesktopComponent } from "../GridsDesktop/GUTAtividadesMatriz";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterGUTAtividadesMatriz } from "../../Filters/GUTAtividadesMatriz";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import GUTAtividadesMatrizWindow from "./GUTAtividadesMatrizWindow";

const GUTAtividadesMatrizGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [gutatividadesmatriz, setGUTAtividadesMatriz] = useState<IGUTAtividadesMatriz[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedGUTAtividadesMatriz, setSelectedGUTAtividadesMatriz] = useState<IGUTAtividadesMatriz>(GUTAtividadesMatrizEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new GUTAtividadesMatrizApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterGUTAtividadesMatriz | undefined | null>(null);

    const gutatividadesmatrizService = useMemo(() => {
      return new GUTAtividadesMatrizService(
          new GUTAtividadesMatrizApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchGUTAtividadesMatriz = async (filtro?: FilterGUTAtividadesMatriz | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await gutatividadesmatrizService.getAll(filtro ?? {} as FilterGUTAtividadesMatriz);
        setGUTAtividadesMatriz(data);
      }
      else {
        const data = await gutatividadesmatrizService.getAll(filtro ?? {} as FilterGUTAtividadesMatriz);
        setGUTAtividadesMatriz(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchGUTAtividadesMatriz(currFilter);
    }, [showInc]);
  
    const handleRowClick = (gutatividadesmatriz: IGUTAtividadesMatriz) => {
      if (isMobile) {
        router.push(`/pages/gutatividadesmatriz/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${gutatividadesmatriz.id}`);
      } else {
        setSelectedGUTAtividadesMatriz(gutatividadesmatriz);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/gutatividadesmatriz/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedGUTAtividadesMatriz(GUTAtividadesMatrizEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchGUTAtividadesMatriz(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const gutatividadesmatriz = e.dataItem;		
        setDeleteId(gutatividadesmatriz.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchGUTAtividadesMatriz(currFilter);
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
           <GUTAtividadesMatrizGridMobileComponent data={gutatividadesmatriz} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <GUTAtividadesMatrizGridDesktopComponent data={gutatividadesmatriz} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <GUTAtividadesMatrizWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedGUTAtividadesMatriz={selectedGUTAtividadesMatriz}>       
        </GUTAtividadesMatrizWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default GUTAtividadesMatrizGrid;