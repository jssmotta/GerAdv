//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AreaEmpty } from "../../../Models/Area";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IArea } from "../../Interfaces/interface.Area";
import { AreaService } from "../../Services/Area.service";
import { AreaApi } from "../../Apis/ApiArea";
import { AreaGridMobileComponent } from "../GridsMobile/Area";
import { AreaGridDesktopComponent } from "../GridsDesktop/Area";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterArea } from "../../Filters/Area";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import AreaWindow from "./AreaWindow";

const AreaGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [area, setArea] = useState<IArea[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedArea, setSelectedArea] = useState<IArea>(AreaEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterArea | undefined | null>(null);

    const areaService = useMemo(() => {
      return new AreaService(
          new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchArea = async (filtro?: FilterArea | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await areaService.getList(filtro ?? {} as FilterArea);
        setArea(data);
      }
      else {
        const data = await areaService.getAll(filtro ?? {} as FilterArea);
        setArea(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchArea(currFilter);
    }, [showInc]);
  
    const handleRowClick = (area: IArea) => {
      if (isMobile) {
        router.push(`/pages/area/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${area.id}`);
      } else {
        setSelectedArea(area);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/area/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedArea(AreaEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchArea(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const area = e.dataItem;		
        setDeleteId(area.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchArea(currFilter);
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
           <AreaGridMobileComponent data={area} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <AreaGridDesktopComponent data={area} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <AreaWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedArea={selectedArea}>       
        </AreaWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AreaGrid;