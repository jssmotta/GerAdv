//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { UltimosProcessosEmpty } from "../../../Models/UltimosProcessos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IUltimosProcessos } from "../../Interfaces/interface.UltimosProcessos";
import { UltimosProcessosService } from "../../Services/UltimosProcessos.service";
import { UltimosProcessosApi } from "../../Apis/ApiUltimosProcessos";
import { UltimosProcessosGridMobileComponent } from "../GridsMobile/UltimosProcessos";
import { UltimosProcessosGridDesktopComponent } from "../GridsDesktop/UltimosProcessos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterUltimosProcessos } from "../../Filters/UltimosProcessos";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import UltimosProcessosWindow from "./UltimosProcessosWindow";

const UltimosProcessosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [ultimosprocessos, setUltimosProcessos] = useState<IUltimosProcessos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedUltimosProcessos, setSelectedUltimosProcessos] = useState<IUltimosProcessos>(UltimosProcessosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new UltimosProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterUltimosProcessos | undefined | null>(null);

    const ultimosprocessosService = useMemo(() => {
      return new UltimosProcessosService(
          new UltimosProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchUltimosProcessos = async (filtro?: FilterUltimosProcessos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await ultimosprocessosService.getAll(filtro ?? {} as FilterUltimosProcessos);
        setUltimosProcessos(data);
      }
      else {
        const data = await ultimosprocessosService.getAll(filtro ?? {} as FilterUltimosProcessos);
        setUltimosProcessos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchUltimosProcessos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (ultimosprocessos: IUltimosProcessos) => {
      if (isMobile) {
        router.push(`/pages/ultimosprocessos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${ultimosprocessos.id}`);
      } else {
        setSelectedUltimosProcessos(ultimosprocessos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/ultimosprocessos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedUltimosProcessos(UltimosProcessosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchUltimosProcessos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const ultimosprocessos = e.dataItem;		
        setDeleteId(ultimosprocessos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchUltimosProcessos(currFilter);
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
           <UltimosProcessosGridMobileComponent data={ultimosprocessos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <UltimosProcessosGridDesktopComponent data={ultimosprocessos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <UltimosProcessosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedUltimosProcessos={selectedUltimosProcessos}>       
        </UltimosProcessosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default UltimosProcessosGrid;