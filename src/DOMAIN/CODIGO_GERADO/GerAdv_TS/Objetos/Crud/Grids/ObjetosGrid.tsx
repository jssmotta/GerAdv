//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ObjetosEmpty } from "../../../Models/Objetos";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IObjetos } from "../../Interfaces/interface.Objetos";
import { ObjetosService } from "../../Services/Objetos.service";
import { ObjetosApi } from "../../Apis/ApiObjetos";
import { ObjetosGridMobileComponent } from "../GridsMobile/Objetos";
import { ObjetosGridDesktopComponent } from "../GridsDesktop/Objetos";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterObjetos } from "../../Filters/Objetos";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ObjetosWindow from "./ObjetosWindow";

const ObjetosGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [objetos, setObjetos] = useState<IObjetos[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedObjetos, setSelectedObjetos] = useState<IObjetos>(ObjetosEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ObjetosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterObjetos | undefined | null>(null);

    const objetosService = useMemo(() => {
      return new ObjetosService(
          new ObjetosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchObjetos = async (filtro?: FilterObjetos | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await objetosService.getList(filtro ?? {} as FilterObjetos);
        setObjetos(data);
      }
      else {
        const data = await objetosService.getAll(filtro ?? {} as FilterObjetos);
        setObjetos(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchObjetos(currFilter);
    }, [showInc]);
  
    const handleRowClick = (objetos: IObjetos) => {
      if (isMobile) {
        router.push(`/pages/objetos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${objetos.id}`);
      } else {
        setSelectedObjetos(objetos);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/objetos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedObjetos(ObjetosEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchObjetos(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const objetos = e.dataItem;		
        setDeleteId(objetos.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchObjetos(currFilter);
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
           <ObjetosGridMobileComponent data={objetos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ObjetosGridDesktopComponent data={objetos} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ObjetosWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedObjetos={selectedObjetos}>       
        </ObjetosWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ObjetosGrid;