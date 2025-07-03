// Diario2GridContainer.test.tsx
import React from 'react';
import { render, screen } from '@testing-library/react';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import Diario2GridContainer from '@/app/GerAdv_TS/Diario2/Components/Diario2GridContainer';
describe('Diario2GridContainer', () => {
  it('renders the grid component output', () => {
    // Mock grid with a render method
    const mockGrid: IGridComponent = {
      render: () => <div data-testid='mock-grid'>Mock Grid Content</div>
    };
    render(<Diario2GridContainer grid={mockGrid} />);
    // Assert the mock grid content is rendered
    expect(screen.getByTestId('mock-grid')).toHaveTextContent('Mock Grid Content');
  });
});