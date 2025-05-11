// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IHorasTrab } from "../../Interfaces/interface.HorasTrab";
import { HorasTrabService } from "../../Services/HorasTrab.service";
import { HorasTrabApi } from "../../Apis/ApiHorasTrab";
import HorasTrabWindow from "./HorasTrabWindow";

interface HorasTrabWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const HorasTrabWindowId: React.FC<HorasTrabWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const horastrabService = useMemo(() => {
        return new HorasTrabService(
            new HorasTrabApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IHorasTrab | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await horastrabService.fetchHorasTrabById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <HorasTrabWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedHorasTrab={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default HorasTrabWindowId;