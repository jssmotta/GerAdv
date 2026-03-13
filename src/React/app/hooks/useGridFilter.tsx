// useGridFilter.tsx
"use client";
import { useState, useMemo, useCallback } from 'react';
import { GridFilterChangeEvent } from '@progress/kendo-react-grid';
import { applyFilterToColumn } from '@/app/tools/crud';

interface UseGridFilterProps<T> {
  data: T[];
  initialFilters: Record<string, any>;
  filterLogic: (item: T, filters: Record<string, any>) => boolean;
}

interface UseGridFilterReturn<T> {
  columnFilters: Record<string, any>;
  filteredData: T[];
  handleFilterChange: (event: GridFilterChangeEvent) => void;
  setColumnFilters: React.Dispatch<React.SetStateAction<Record<string, any>>>;
}

export const useGridFilter = <T,>({
  data,
  initialFilters,
  filterLogic,
}: UseGridFilterProps<T>): UseGridFilterReturn<T> => {
  const [columnFilters, setColumnFilters] = useState(initialFilters);

  // Memoiza a função de filtro para evitar recriações desnecessárias
  const memoizedFilterLogic = useCallback(filterLogic, [filterLogic]);

  const filteredData = useMemo(() => {
    return data.filter((item: T) => memoizedFilterLogic(item, columnFilters));
  }, [data, columnFilters, memoizedFilterLogic]);

  const handleFilterChange = (event: GridFilterChangeEvent) => {
    const filters = event.filter?.filters || [];
    const newColumnFilters = { ...initialFilters };

    filters.forEach((filter) => applyFilterToColumn(filter, newColumnFilters));

    setColumnFilters(newColumnFilters);
  };

  return {
    columnFilters,
    filteredData,
    handleFilterChange,
    setColumnFilters,
  };
};