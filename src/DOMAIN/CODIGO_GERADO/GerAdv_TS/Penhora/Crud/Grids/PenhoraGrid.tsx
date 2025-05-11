//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { PenhoraEmpty } from "../../../Models/Penhora";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IPenhora } from "../../Interfaces/interface.Penhora";
import { PenhoraService } from "../../Services/Penhora.service";
import { PenhoraApi } from "../../Apis/ApiPenhora";
import { PenhoraGridMobileComponent } from "../GridsMobile/Penhora";
import { PenhoraGridDesktopComponent } from "../GridsDesktop/Penhora";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterPenhora } from "../../Filters/Penhora";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import PenhoraWindow from "./PenhoraWindow";

const PenhoraGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [penhora, setPenhora] = useState<IPenhora[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedPenhora, setSelectedPenhora] = useState<IPenhora>(PenhoraEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new PenhoraApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterPenhora | undefined | null>(null);

    const penhoraService = useMemo(() => {
      return new PenhoraService(
          new PenhoraApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchPenhora = async (filtro?: FilterPenhora | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await penhoraService.getList(filtro ?? {} as FilterPenhora);
        setPenhora(data);
      }
      else {
        const data = await penhoraService.getAll(filtro ?? {} as FilterPenhora);
        setPenhora(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchPenhora(currFilter);
    }, [showInc]);
  
    const handleRowClick = (penhora: IPenhora) => {
      if (isMobile) {
        router.push(`/pages/penhora/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${penhora.id}`);
      } else {
        setSelectedPenhora(penhora);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/penhora/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedPenhora(PenhoraEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchPenhora(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const penhora = e.dataItem;		
        setDeleteId(penhora.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchPenhora(currFilter);
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
           <PenhoraGridMobileComponent data={penhora} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <PenhoraGridDesktopComponent data={penhora} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <PenhoraWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedPenhora={selectedPenhora}>       
        </PenhoraWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default PenhoraGrid;