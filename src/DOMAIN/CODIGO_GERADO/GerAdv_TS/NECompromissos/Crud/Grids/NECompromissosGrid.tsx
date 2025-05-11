//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { NECompromissosEmpty } from "../../../Models/NECompromissos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { INECompromissos } from "../../Interfaces/interface.NECompromissos";
import { NECompromissosService } from "../../Services/NECompromissos.service";
import { NECompromissosApi } from "../../Apis/ApiNECompromissos";
import { NECompromissosGridMobileComponent } from "../GridsMobile/NECompromissos";
import { NECompromissosGridDesktopComponent } from "../GridsDesktop/NECompromissos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterNECompromissos } from "../../Filters/NECompromissos";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import NECompromissosWindow from "./NECompromissosWindow";

const NECompromissosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [necompromissos, setNECompromissos] = useState<INECompromissos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedNECompromissos, setSelectedNECompromissos] = useState<INECompromissos>(NECompromissosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new NECompromissosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterNECompromissos | undefined | null>(null);

    const necompromissosService = useMemo(() => {
      return new NECompromissosService(
          new NECompromissosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchNECompromissos = async (filtro?: FilterNECompromissos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await necompromissosService.getAll(filtro ?? {} as FilterNECompromissos);
        setNECompromissos(data);
      }
      else {
        const data = await necompromissosService.getAll(filtro ?? {} as FilterNECompromissos);
        setNECompromissos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchNECompromissos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (necompromissos: INECompromissos) => {
      if (isMobile) {
        router.push(`/pages/necompromissos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${necompromissos.id}`);
      } else {
        setSelectedNECompromissos(necompromissos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/necompromissos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedNECompromissos(NECompromissosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchNECompromissos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const necompromissos = e.dataItem;		
        setDeleteId(necompromissos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchNECompromissos(currFilter);
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
           <NECompromissosGridMobileComponent data={necompromissos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <NECompromissosGridDesktopComponent data={necompromissos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <NECompromissosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedNECompromissos={selectedNECompromissos}>       
        </NECompromissosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default NECompromissosGrid;