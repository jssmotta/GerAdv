//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { CargosEscClassEmpty } from "../../../Models/CargosEscClass";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { ICargosEscClass } from "../../Interfaces/interface.CargosEscClass";
import { CargosEscClassService } from "../../Services/CargosEscClass.service";
import { CargosEscClassApi } from "../../Apis/ApiCargosEscClass";
import { CargosEscClassGridMobileComponent } from "../GridsMobile/CargosEscClass";
import { CargosEscClassGridDesktopComponent } from "../GridsDesktop/CargosEscClass";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterCargosEscClass } from "../../Filters/CargosEscClass";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import CargosEscClassWindow from "./CargosEscClassWindow";

const CargosEscClassGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [cargosescclass, setCargosEscClass] = useState<ICargosEscClass[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedCargosEscClass, setSelectedCargosEscClass] = useState<ICargosEscClass>(CargosEscClassEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new CargosEscClassApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterCargosEscClass | undefined | null>(null);

    const cargosescclassService = useMemo(() => {
      return new CargosEscClassService(
          new CargosEscClassApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchCargosEscClass = async (filtro?: FilterCargosEscClass | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await cargosescclassService.getList(filtro ?? {} as FilterCargosEscClass);
        setCargosEscClass(data);
      }
      else {
        const data = await cargosescclassService.getAll(filtro ?? {} as FilterCargosEscClass);
        setCargosEscClass(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchCargosEscClass(currFilter);
    }, [showInc]);
  
    const handleRowClick = (cargosescclass: ICargosEscClass) => {
      if (isMobile) {
        router.push(`/pages/cargosescclass/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${cargosescclass.id}`);
      } else {
        setSelectedCargosEscClass(cargosescclass);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/cargosescclass/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedCargosEscClass(CargosEscClassEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchCargosEscClass(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const cargosescclass = e.dataItem;		
        setDeleteId(cargosescclass.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchCargosEscClass(currFilter);
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
           <CargosEscClassGridMobileComponent data={cargosescclass} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <CargosEscClassGridDesktopComponent data={cargosescclass} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <CargosEscClassWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedCargosEscClass={selectedCargosEscClass}>       
        </CargosEscClassWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default CargosEscClassGrid;