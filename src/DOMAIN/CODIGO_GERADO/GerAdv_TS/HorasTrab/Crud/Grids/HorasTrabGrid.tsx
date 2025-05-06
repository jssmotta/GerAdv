//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { HorasTrabEmpty } from "../../../Models/HorasTrab";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IHorasTrab } from "../../Interfaces/interface.HorasTrab";
import { HorasTrabService } from "../../Services/HorasTrab.service";
import { HorasTrabApi } from "../../Apis/ApiHorasTrab";
import { HorasTrabGridMobileComponent } from "../GridsMobile/HorasTrab";
import { HorasTrabGridDesktopComponent } from "../GridsDesktop/HorasTrab";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterHorasTrab } from "../../Filters/HorasTrab";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import HorasTrabWindow from "./HorasTrabWindow";

const HorasTrabGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [horastrab, setHorasTrab] = useState<IHorasTrab[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedHorasTrab, setSelectedHorasTrab] = useState<IHorasTrab>(HorasTrabEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new HorasTrabApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterHorasTrab | undefined | null>(null);

    const horastrabService = useMemo(() => {
      return new HorasTrabService(
          new HorasTrabApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchHorasTrab = async (filtro?: FilterHorasTrab | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await horastrabService.getAll(filtro ?? {} as FilterHorasTrab);
        setHorasTrab(data);
      }
      else {
        const data = await horastrabService.getAll(filtro ?? {} as FilterHorasTrab);
        setHorasTrab(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchHorasTrab(currFilter);
    }, [showInc]);
  
    const handleRowClick = (horastrab: IHorasTrab) => {
      if (isMobile) {
        router.push(`/pages/horastrab/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${horastrab.id}`);
      } else {
        setSelectedHorasTrab(horastrab);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/horastrab/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedHorasTrab(HorasTrabEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchHorasTrab(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const horastrab = e.dataItem;		
        setDeleteId(horastrab.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchHorasTrab(currFilter);
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
           <HorasTrabGridMobileComponent data={horastrab} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <HorasTrabGridDesktopComponent data={horastrab} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <HorasTrabWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedHorasTrab={selectedHorasTrab}>       
        </HorasTrabWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default HorasTrabGrid;