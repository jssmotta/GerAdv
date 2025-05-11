// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IAreasJustica } from "../../Interfaces/interface.AreasJustica";
import { AreasJusticaService } from "../../Services/AreasJustica.service";
import { AreasJusticaApi } from "../../Apis/ApiAreasJustica";
import AreasJusticaWindow from "./AreasJusticaWindow";

interface AreasJusticaWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const AreasJusticaWindowId: React.FC<AreasJusticaWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const areasjusticaService = useMemo(() => {
        return new AreasJusticaService(
            new AreasJusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IAreasJustica | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await areasjusticaService.fetchAreasJusticaById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <AreasJusticaWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedAreasJustica={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default AreasJusticaWindowId;