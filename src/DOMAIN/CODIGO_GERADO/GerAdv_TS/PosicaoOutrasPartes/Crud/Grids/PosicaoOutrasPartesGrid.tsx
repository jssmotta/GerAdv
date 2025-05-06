//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { PosicaoOutrasPartesEmpty } from "../../../Models/PosicaoOutrasPartes";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IPosicaoOutrasPartes } from "../../Interfaces/interface.PosicaoOutrasPartes";
import { PosicaoOutrasPartesService } from "../../Services/PosicaoOutrasPartes.service";
import { PosicaoOutrasPartesApi } from "../../Apis/ApiPosicaoOutrasPartes";
import { PosicaoOutrasPartesGridMobileComponent } from "../GridsMobile/PosicaoOutrasPartes";
import { PosicaoOutrasPartesGridDesktopComponent } from "../GridsDesktop/PosicaoOutrasPartes";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterPosicaoOutrasPartes } from "../../Filters/PosicaoOutrasPartes";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import PosicaoOutrasPartesWindow from "./PosicaoOutrasPartesWindow";

const PosicaoOutrasPartesGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [posicaooutraspartes, setPosicaoOutrasPartes] = useState<IPosicaoOutrasPartes[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedPosicaoOutrasPartes, setSelectedPosicaoOutrasPartes] = useState<IPosicaoOutrasPartes>(PosicaoOutrasPartesEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new PosicaoOutrasPartesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterPosicaoOutrasPartes | undefined | null>(null);

    const posicaooutraspartesService = useMemo(() => {
      return new PosicaoOutrasPartesService(
          new PosicaoOutrasPartesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchPosicaoOutrasPartes = async (filtro?: FilterPosicaoOutrasPartes | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await posicaooutraspartesService.getList(filtro ?? {} as FilterPosicaoOutrasPartes);
        setPosicaoOutrasPartes(data);
      }
      else {
        const data = await posicaooutraspartesService.getAll(filtro ?? {} as FilterPosicaoOutrasPartes);
        setPosicaoOutrasPartes(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchPosicaoOutrasPartes(currFilter);
    }, [showInc]);
  
    const handleRowClick = (posicaooutraspartes: IPosicaoOutrasPartes) => {
      if (isMobile) {
        router.push(`/pages/posicaooutraspartes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${posicaooutraspartes.id}`);
      } else {
        setSelectedPosicaoOutrasPartes(posicaooutraspartes);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/posicaooutraspartes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedPosicaoOutrasPartes(PosicaoOutrasPartesEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchPosicaoOutrasPartes(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const posicaooutraspartes = e.dataItem;		
        setDeleteId(posicaooutraspartes.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchPosicaoOutrasPartes(currFilter);
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
           <PosicaoOutrasPartesGridMobileComponent data={posicaooutraspartes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <PosicaoOutrasPartesGridDesktopComponent data={posicaooutraspartes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <PosicaoOutrasPartesWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedPosicaoOutrasPartes={selectedPosicaoOutrasPartes}>       
        </PosicaoOutrasPartesWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default PosicaoOutrasPartesGrid;