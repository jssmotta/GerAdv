//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { TribunalEmpty } from "../../../Models/Tribunal";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import TribunalInc from "../Inc/Tribunal";
import { ITribunal } from "../../Interfaces/interface.Tribunal";
import { TribunalService } from "../../Services/Tribunal.service";
import { TribunalApi } from "../../Apis/ApiTribunal";
import { TribunalGridMobileComponent } from "../GridsMobile/Tribunal";
import { TribunalGridDesktopComponent } from "../GridsDesktop/Tribunal";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterTribunal } from "../../Filters/Tribunal";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import TribunalWindow from "./TribunalWindow";

const TribunalGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [tribunal, setTribunal] = useState<ITribunal[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedTribunal, setSelectedTribunal] = useState<ITribunal>(TribunalEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new TribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterTribunal | undefined | null>(null);

    const tribunalService = useMemo(() => {
      return new TribunalService(
          new TribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchTribunal = async (filtro?: FilterTribunal | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await tribunalService.getList(filtro ?? {} as FilterTribunal);
        setTribunal(data);
      }
      else {
        const data = await tribunalService.getAll(filtro ?? {} as FilterTribunal);
        setTribunal(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchTribunal(currFilter);
    }, [showInc]);
  
    const handleRowClick = (tribunal: ITribunal) => {
      if (isMobile) {
        router.push(`/pages/tribunal/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${tribunal.id}`);
      } else {
        setSelectedTribunal(tribunal);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/tribunal/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedTribunal(TribunalEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchTribunal(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const tribunal = e.dataItem;		
        setDeleteId(tribunal.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchTribunal(currFilter);
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
           <TribunalGridMobileComponent data={tribunal} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <TribunalGridDesktopComponent data={tribunal} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <TribunalWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedTribunal={selectedTribunal}>       
        </TribunalWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default TribunalGrid;