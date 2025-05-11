// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IFase } from "../../Interfaces/interface.Fase";
import { FaseService } from "../../Services/Fase.service";
import { FaseApi } from "../../Apis/ApiFase";
import FaseWindow from "./FaseWindow";

interface FaseWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const FaseWindowId: React.FC<FaseWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const faseService = useMemo(() => {
        return new FaseService(
            new FaseApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IFase | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await faseService.fetchFaseById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <FaseWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedFase={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default FaseWindowId;