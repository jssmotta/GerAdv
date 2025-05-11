// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IRecados } from "../../Interfaces/interface.Recados";
import { RecadosService } from "../../Services/Recados.service";
import { RecadosApi } from "../../Apis/ApiRecados";
import RecadosWindow from "./RecadosWindow";

interface RecadosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const RecadosWindowId: React.FC<RecadosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const recadosService = useMemo(() => {
        return new RecadosService(
            new RecadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IRecados | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await recadosService.fetchRecadosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <RecadosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedRecados={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default RecadosWindowId;