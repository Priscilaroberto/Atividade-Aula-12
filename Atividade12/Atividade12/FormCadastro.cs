﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade12
{
    public partial class FormCadastro : Form
    {
        private object productId;

        public FormCadastro()
        {
            InitializeComponent();
        }

        private void FormCadastro_Load(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            decimal preco = Convert.ToDecimal(txtPreco.Text);

            db.OpenConnection();
            string query;

            if (productId == null) // Inserção
            {
                query = "INSERT INTO Produto (Nome, Preco) VALUES (@nome, @preco)";
            }
            else // Atualização
            {
                query = "UPDATE Produto SET Nome = @nome, Preco = @preco WHERE Id = @id";
            }

            MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@preco", preco);

            if (productId != null)
            {
                cmd.Parameters.AddWithValue("@id", productId);
            }

            cmd.ExecuteNonQuery();
            db.CloseConnection();
            DialogResult = DialogResult.OK; // Fecha o formulário
        }
    }
}

