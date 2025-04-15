//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TerceirosEmpty } from "../../../Models/Terceiros";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import TerceirosInc from "../Inc/Terceiros";
import { ITerceiros } from "../../Interfaces/interface.Terceiros";
import { TerceirosService } from "../../Services/Terceiros.service";
import { TerceirosApi } from "../../Apis/ApiTerceiros";
import { TerceirosGridMobileComponent } from "../GridsMobile/Terceiros";
import { TerceirosGridDesktopComponent } from "../GridsDesktop/Terceiros";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTerceiros } from "../../Filters/Terceiros";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import TerceirosWindow from "./TerceirosWindow";

const TerceirosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [terceiros, setTerceiros] = useState<ITerceiros[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTerceiros, setSelectedTerceiros] = useState<ITerceiros>(TerceirosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TerceirosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTerceiros | undefined | null>(null);

    const terceirosService = useMemo(() => {
      return new TerceirosService(
          new TerceirosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTerceiros = async (filtro?: FilterTerceiros | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await terceirosService.getList(filtro ?? {} as FilterTerceiros);
        setTerceiros(data);
      }
      else {
        const data = await terceirosService.getAll(filtro ?? {} as FilterTerceiros);
        setTerceiros(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTerceiros(currFilter);
    }, [showInc]);
  
    const handleRowClick = (terceiros: ITerceiros) => {
      if (isMobile) {
        router.push(`/pages/terceiros/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${terceiros.id}`);
      } else {
        setSelectedTerceiros(terceiros);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/terceiros/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTerceiros(TerceirosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTerceiros(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const terceiros = e.dataItem;		
        setDeleteId(terceiros.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTerceiros(currFilter);
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
           <TerceirosGridMobileComponent data={terceiros} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <TerceirosGridDesktopComponent data={terceiros} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <TerceirosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTerceiros={selectedTerceiros}>       
        </TerceirosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TerceirosGrid;