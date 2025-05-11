//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { FaseEmpty } from "../../../Models/Fase";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IFase } from "../../Interfaces/interface.Fase";
import { FaseService } from "../../Services/Fase.service";
import { FaseApi } from "../../Apis/ApiFase";
import { FaseGridMobileComponent } from "../GridsMobile/Fase";
import { FaseGridDesktopComponent } from "../GridsDesktop/Fase";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterFase } from "../../Filters/Fase";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import FaseWindow from "./FaseWindow";

const FaseGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [fase, setFase] = useState<IFase[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedFase, setSelectedFase] = useState<IFase>(FaseEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new FaseApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterFase | undefined | null>(null);

    const faseService = useMemo(() => {
      return new FaseService(
          new FaseApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchFase = async (filtro?: FilterFase | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await faseService.getList(filtro ?? {} as FilterFase);
        setFase(data);
      }
      else {
        const data = await faseService.getAll(filtro ?? {} as FilterFase);
        setFase(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchFase(currFilter);
    }, [showInc]);
  
    const handleRowClick = (fase: IFase) => {
      if (isMobile) {
        router.push(`/pages/fase/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${fase.id}`);
      } else {
        setSelectedFase(fase);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/fase/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedFase(FaseEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchFase(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const fase = e.dataItem;		
        setDeleteId(fase.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchFase(currFilter);
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
           <FaseGridMobileComponent data={fase} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <FaseGridDesktopComponent data={fase} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <FaseWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedFase={selectedFase}>       
        </FaseWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default FaseGrid;