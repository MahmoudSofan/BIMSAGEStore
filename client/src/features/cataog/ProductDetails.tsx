import { Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, Typography } from '@mui/material';
import axios from 'axios';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Product } from '../../app/models/product';

export default function ProductDetails() {
  const { id } = useParams<{ id: string }>();
  const [product, setProduct] = useState<Product | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    axios
      .get(`https://localhost:7127/api/product/${id}`)
      .then((response) => setProduct(response.data))
      .catch((error) => console.log(error))
      .finally(() => setLoading(false));
  }, [id]);

  if (loading) return <h3>Loading...</h3>;

  if (!product) return <h3>Product is not found!</h3>;

  return (
    <Grid container spacing={6}>
      <Grid item xs={6}>
        <img
          src={`${process.env.PUBLIC_URL}/${product.pictureUrl}`}
          alt={product.name}
          style={{ width: '100%' }}
          onError={(e) => {
            console.error('Error loading image:', e);
          }}
        />
      </Grid>
      <Grid item xs={6}>
        <Typography variant="h3">{product.name}</Typography>
        <Divider sx={{ mb: 2 }} />
        <Typography variant="h3" color="secondary">
          ${product.price}
        </Typography>
        <TableContainer>
          <Table>
            <TableBody>
              <TableRow>
              <TableCell>Name</TableCell>
              <TableCell>{product.name}</TableCell>
              </TableRow>

              <TableRow>
              <TableCell>Description</TableCell>
              <TableCell>{product.description}</TableCell>
              </TableRow>

              <TableRow>
              <TableCell>Type</TableCell>
              <TableCell>{product.type}</TableCell>
              </TableRow>

              <TableRow>
              <TableCell>Brand</TableCell>
              <TableCell>{product.brand}</TableCell>
              </TableRow>

              <TableRow>
              <TableCell>Sold</TableCell>
              <TableCell>{product.quantityInStock}</TableCell>
              </TableRow>

            </TableBody>
          </Table>
        </TableContainer>
      </Grid>
    </Grid>
  );
}
