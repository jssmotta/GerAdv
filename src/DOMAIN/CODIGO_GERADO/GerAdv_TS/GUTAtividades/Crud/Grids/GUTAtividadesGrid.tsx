//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { GUTAtividadesEmpty } from "../../../Models/GUTAtividades";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import GUTAtividadesInc from "../Inc/GUTAtividades";
import { IGUTAtividades } from "../../Interfaces/interface.GUTAtividades";
import { GUTAtividadesService } from "../../Services/GUTAtividades.service";
import { GUTAtividadesApi } from "../../Apis/ApiGUTAtividades";
import { GUTAtividadesGridMobileComponent } from "../GridsMobile/GUTAtividades";
import { GUTAtividadesGridDesktopComponent } from "../GridsDesktop/GUTAtividades";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterGUTAtividades } from "../../Filters/GUTAtividades";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import GUTAtividadesWindow from "./GUTAtividadesWindow";

const GUTAtividadesGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [gutatividades, setGUTAtividades] = useState<IGUTAtividades[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedGUTAtividades, setSelectedGUTAtividades] = useState<IGUTAtividades>(GUTAtividadesEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new GUTAtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterGUTAtividades | undefined | null>(null);

    const gutatividadesService = useMemo(() => {
      return new GUTAtividadesService(
          new GUTAtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchGUTAtividades = async (filtro?: FilterGUTAtividades | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await gutatividadesService.getList(filtro ?? {} as FilterGUTAtividades);
        setGUTAtividades(data);
      }
      else {
        const data = await gutatividadesService.getAll(filtro ?? {} as FilterGUTAtividades);
        setGUTAtividades(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchGUTAtividades(currFilter);
    }, [showInc]);
  
    const handleRowClick = (gutatividades: IGUTAtividades) => {
      if (isMobile) {
        router.push(`/pages/gutatividades/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${gutatividades.id}`);
      } else {
        setSelectedGUTAtividades(gutatividades);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/gutatividades/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedGUTAtividades(GUTAtividadesEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchGUTAtividades(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const gutatividades = e.dataItem;		
        setDeleteId(gutatividades.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchGUTAtividades(currFilter);
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
           <GUTAtividadesGridMobileComponent data={gutatividades} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <GUTAtividadesGridDesktopComponent data={gutatividades} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <GUTAtividadesWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedGUTAtividades={selectedGUTAtividades}>       
        </GUTAtividadesWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default GUTAtividadesGrid;