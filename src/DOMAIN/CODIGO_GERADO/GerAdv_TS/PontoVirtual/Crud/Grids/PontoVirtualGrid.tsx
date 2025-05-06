//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { PontoVirtualEmpty } from "../../../Models/PontoVirtual";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IPontoVirtual } from "../../Interfaces/interface.PontoVirtual";
import { PontoVirtualService } from "../../Services/PontoVirtual.service";
import { PontoVirtualApi } from "../../Apis/ApiPontoVirtual";
import { PontoVirtualGridMobileComponent } from "../GridsMobile/PontoVirtual";
import { PontoVirtualGridDesktopComponent } from "../GridsDesktop/PontoVirtual";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterPontoVirtual } from "../../Filters/PontoVirtual";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import PontoVirtualWindow from "./PontoVirtualWindow";

const PontoVirtualGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [pontovirtual, setPontoVirtual] = useState<IPontoVirtual[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedPontoVirtual, setSelectedPontoVirtual] = useState<IPontoVirtual>(PontoVirtualEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new PontoVirtualApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterPontoVirtual | undefined | null>(null);

    const pontovirtualService = useMemo(() => {
      return new PontoVirtualService(
          new PontoVirtualApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchPontoVirtual = async (filtro?: FilterPontoVirtual | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await pontovirtualService.getAll(filtro ?? {} as FilterPontoVirtual);
        setPontoVirtual(data);
      }
      else {
        const data = await pontovirtualService.getAll(filtro ?? {} as FilterPontoVirtual);
        setPontoVirtual(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchPontoVirtual(currFilter);
    }, [showInc]);
  
    const handleRowClick = (pontovirtual: IPontoVirtual) => {
      if (isMobile) {
        router.push(`/pages/pontovirtual/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${pontovirtual.id}`);
      } else {
        setSelectedPontoVirtual(pontovirtual);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/pontovirtual/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedPontoVirtual(PontoVirtualEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchPontoVirtual(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const pontovirtual = e.dataItem;		
        setDeleteId(pontovirtual.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchPontoVirtual(currFilter);
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
           <PontoVirtualGridMobileComponent data={pontovirtual} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <PontoVirtualGridDesktopComponent data={pontovirtual} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <PontoVirtualWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedPontoVirtual={selectedPontoVirtual}>       
        </PontoVirtualWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default PontoVirtualGrid;