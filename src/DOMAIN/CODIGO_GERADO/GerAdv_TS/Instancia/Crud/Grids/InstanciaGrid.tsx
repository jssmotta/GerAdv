//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { InstanciaEmpty } from "../../../Models/Instancia";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IInstancia } from "../../Interfaces/interface.Instancia";
import { InstanciaService } from "../../Services/Instancia.service";
import { InstanciaApi } from "../../Apis/ApiInstancia";
import { InstanciaGridMobileComponent } from "../GridsMobile/Instancia";
import { InstanciaGridDesktopComponent } from "../GridsDesktop/Instancia";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterInstancia } from "../../Filters/Instancia";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import InstanciaWindow from "./InstanciaWindow";

const InstanciaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [instancia, setInstancia] = useState<IInstancia[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedInstancia, setSelectedInstancia] = useState<IInstancia>(InstanciaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new InstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterInstancia | undefined | null>(null);

    const instanciaService = useMemo(() => {
      return new InstanciaService(
          new InstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchInstancia = async (filtro?: FilterInstancia | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await instanciaService.getList(filtro ?? {} as FilterInstancia);
        setInstancia(data);
      }
      else {
        const data = await instanciaService.getAll(filtro ?? {} as FilterInstancia);
        setInstancia(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchInstancia(currFilter);
    }, [showInc]);
  
    const handleRowClick = (instancia: IInstancia) => {
      if (isMobile) {
        router.push(`/pages/instancia/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${instancia.id}`);
      } else {
        setSelectedInstancia(instancia);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/instancia/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedInstancia(InstanciaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchInstancia(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const instancia = e.dataItem;		
        setDeleteId(instancia.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchInstancia(currFilter);
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
           <InstanciaGridMobileComponent data={instancia} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <InstanciaGridDesktopComponent data={instancia} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <InstanciaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedInstancia={selectedInstancia}>       
        </InstanciaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default InstanciaGrid;